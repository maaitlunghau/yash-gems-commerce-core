using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto productDto)
        {
            try
            {
                await _productService.UpdateProductAsync(id, productDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/images")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> UploadProductImages(int id, List<IFormFile> files)
        {
            if (files == null || !files.Any()) return BadRequest("No files uploaded.");

            var fileStreams = files.Select(f => (f.OpenReadStream(), f.FileName)).ToList();
            
            var imagesDto = await _productService.AddProductImagesAsync(id, fileStreams);

            // Đóng stream sau khi sử dụng (Nghiệp vụ kỹ lưỡng)
            foreach (var stream in fileStreams)
            {
                stream.Item1.Dispose();
            }

            return Ok(imagesDto);
        }

        [HttpDelete("{id}/images")]
        public async Task<IActionResult> DeleteProductImages(int id, [FromBody] List<int> imageIds)
        {
            if (imageIds == null || !imageIds.Any()) return BadRequest("No image IDs provided.");

            var result = await _productService.DeleteProductImagesAsync(id, imageIds);
            
            if (!result) return BadRequest("Could not delete images or images not found.");

            return NoContent();
        }
    }
}
