using CRUDWithBlazor.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace CRUDWithBlazor.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(Product model)
        {
            if (model is null) return null!;
            var chk = await _context.Products.Where(_ => _.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null!;

            var newDataAdded = _context.Products.Add(model).Entity;
            await _context.SaveChangesAsync();
            return newDataAdded;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (product is null) return null!;
            product.Name = model.Name;
            product.Quantity = model.Quantity;
            await _context.SaveChangesAsync();
            return await _context.Products.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(_ => _.Id == productId);
            if (product is null) return null!;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null) return null!;
            return product;
        }
    }
}