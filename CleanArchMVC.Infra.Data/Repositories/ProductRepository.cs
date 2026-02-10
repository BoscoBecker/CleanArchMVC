using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace CleanArchMVC.Infra.Data.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;   

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _context.Products.AsNoTracking()
                                           .Include(p => p.Category)
                                           .SingleOrDefaultAsync(c => c.Id == id);
            return  product == null ? throw new ApplicationException("Entity could not be loaded.") : await product;

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           var products = _context.Products.AsNoTracking().ToListAsync();
           return await products;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
