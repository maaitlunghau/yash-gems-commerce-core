using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        // Giả sử giá vàng hiện tại là 70$ / gram 
        // Sau này có thể query từ bảng cấu hình cài đặt SystemSettings
        private const decimal CURRENT_GOLD_RATE_PER_GRAM = 70m;

        public ProductService(
            IProductRepository productRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IPhotoService photoService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductByStyleCodeAsync(string styleCode)
        {
            var product = await _productRepository.GetByStyleCodeAsync(styleCode);
            if (product == null) throw new KeyNotFoundException($"Product with StyleCode {styleCode} not found.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            // tự động tính giá MRP khi tạo mới
            product.MRP = CalculateMRP(product);

            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null) throw new KeyNotFoundException($"Product with ID {id} not found.");

            _mapper.Map(productDto, existingProduct);

            // tính lại giá MRP nếu các yếu tố cấu thành giá thay đổi
            existingProduct.MRP = CalculateMRP(existingProduct);

            await _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");

            await _productRepository.Delete(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<ProductImageDto> AddProductImageAsync(int productId, Stream stream, string fileName)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new KeyNotFoundException($"Product with ID {productId} not found.");

            var (url, publicId) = await _photoService.AddPhotoAsync(stream, fileName);

            var productImage = new ProductImage
            {
                Url = url,
                PublicId = publicId,
                IsMain = product.Images == null || !product.Images.Any(),
                ProductId = productId
            };

            product.Images ??= new List<ProductImage>();
            product.Images.Add(productImage);

            await _productRepository.Update(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductImageDto>(productImage);
        }

        public async Task<IEnumerable<ProductImageDto>> AddProductImagesAsync(int productId, List<(Stream stream, string fileName)> files)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new KeyNotFoundException($"Product with ID {productId} not found.");

            var uploadedImages = new List<ProductImage>();

            foreach (var (stream, fileName) in files)
            {
                var (url, publicId) = await _photoService.AddPhotoAsync(stream, fileName);

                var productImage = new ProductImage
                {
                    Url = url,
                    PublicId = publicId,
                    IsMain = (product.Images == null || !product.Images.Any()) && uploadedImages.Count == 0,
                    ProductId = productId
                };

                uploadedImages.Add(productImage);
            }

            product.Images ??= new List<ProductImage>();
            foreach (var img in uploadedImages)
            {
                product.Images.Add(img);
            }

            await _productRepository.Update(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<IEnumerable<ProductImageDto>>(uploadedImages);
        }

        public async Task<bool> DeleteProductImagesAsync(int productId, List<int> imageIds)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new KeyNotFoundException($"Product with ID {productId} not found.");

            var imagesToDelete = product.Images?
                .Where(img => imageIds.Contains(img.Id))
                .ToList();

            if (imagesToDelete == null || !imagesToDelete.Any()) return false;

            // 1. Xóa trên Cloudinary hàng loạt
            var publicIds = imagesToDelete.Select(x => x.PublicId).ToList();
            await _photoService.DeletePhotosAsync(publicIds);

            // 2. Xóa trong Database (EF Core sẽ tự động dọn bản ghi nếu là cascade hoặc ta remove khỏi collection)
            foreach (var img in imagesToDelete)
            {
                product.Images!.Remove(img);
            }

            await _productRepository.Update(product);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        /* 
         * Công thức: 
         * MRP = (Net_Gold * Gold_Rate) + Gold_Making + Stone_Making + Other_Making + (Wastage * Gold_Rate) + Tax
         */
        private decimal CalculateMRP(Product product)
        {
            decimal goldWeight = product.GoldWeight ?? 0m;
            decimal goldValue = goldWeight * CURRENT_GOLD_RATE_PER_GRAM;

            decimal wastageValue = (product.Wastage / 100m) * goldValue;

            decimal subTotal = goldValue
                             + product.GoldMakingCharge
                             + product.StoneMakingCharge
                             + product.OtherMakingCharge
                             + wastageValue;

            decimal taxAmount = subTotal * (product.Tax / 100m);

            return subTotal + taxAmount;
        }
    }
}
