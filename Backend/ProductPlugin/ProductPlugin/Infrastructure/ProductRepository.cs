using Microsoft.EntityFrameworkCore;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;

namespace Plugin.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) => _context = context;
        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
        public async Task<Product> GetByNameAsync(string name, int id) => await _context.Products.FirstOrDefaultAsync(x => x.Name == name && x.Id != id);
        public async Task<Product> GetByCodeAsync(string code, int id) => await _context.Products.FirstOrDefaultAsync(x => x.Code == code && x.Id != id);
        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        public async Task AddAsync(Product entity) => await _context.Products.AddAsync(entity);
        public void Update(Product entity) => _context.Products.Update(entity);
        public void Remove(Product entity) => _context.Products.Remove(entity);
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }

}
