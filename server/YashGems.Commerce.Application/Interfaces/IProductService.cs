using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> GetProductByStyleCodeAsync(string styleCode);
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int id, UpdateProductDto productDto);
        Task DeleteProductAsync(int id);
        Task<ProductImageDto> AddProductImageAsync(int productId, Stream stream, string fileName);

        Task<IEnumerable<ProductImageDto>> AddProductImagesAsync(int productId, List<(Stream stream, string fileName)> files);
        Task<bool> DeleteProductImagesAsync(int productId, List<int> imageIds);
    }
}
