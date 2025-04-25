using Plugin.Domain.Models;

namespace Plugin.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product p);
        Task<Product> UpdateAsync(Product p);
        Task<int> DeleteAsync(int id);
        Task<Product> GetAsync(int id);
        Task<List<Product>> ListAsync();
    }
}
