using Plugin.Domain.Models;

namespace Plugin.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByCodeAsync(string code, int id);
        Task<Product> GetByNameAsync(string name, int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product entity);
        void Update(Product entity);
        void Remove(Product entity);
        Task<int> SaveChangesAsync();
    }
}
