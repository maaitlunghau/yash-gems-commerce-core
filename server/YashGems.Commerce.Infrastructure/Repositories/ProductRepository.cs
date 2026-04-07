using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.JewelType)
                .Include(p => p.Certification)
                .Include(p => p.GoldKarat)
                .Include(p => p.DiamondColor)
                .Include(p => p.DiamondClarity)
                .Include(p => p.DiamondCut)
                .Include(p => p.GemstoneType)
                .Include(p => p.StoneQuality)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.JewelType)
                .Include(p => p.Certification)
                .Include(p => p.GoldKarat)
                .Include(p => p.DiamondColor)
                .Include(p => p.DiamondClarity)
                .Include(p => p.DiamondCut)
                .Include(p => p.GemstoneType)
                .Include(p => p.StoneQuality)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByStyleCodeAsync(string styleCode)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.JewelType)
                .Include(p => p.Certification)
                .Include(p => p.GoldKarat)
                .Include(p => p.DiamondColor)
                .Include(p => p.DiamondClarity)
                .Include(p => p.DiamondCut)
                .Include(p => p.GemstoneType)
                .Include(p => p.StoneQuality)
                .FirstOrDefaultAsync(p => p.StyleCode == styleCode);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public Task Update(Product product)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }

        public Task Delete(Product product)
        {
            _context.Products.Remove(product);
            return Task.CompletedTask;
        }
    }
}
