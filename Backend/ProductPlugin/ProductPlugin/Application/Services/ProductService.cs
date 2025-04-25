using Plugin.Application.Common.Exceptions;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;

namespace Plugin.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IPricingStrategy _pricingStrategy;

        public ProductService(IProductRepository repository, IPricingStrategy pricingStrategy)
        {
            _repository = repository;
            _pricingStrategy = pricingStrategy;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Price = _pricingStrategy.CalculatePrice(product);
            if (await _repository.GetByCodeAsync(product.Code,product.Id) != null)
                throw new DuplicateProductCodeException(product.Code);
            if (await _repository.GetByNameAsync(product.Name, product.Id) != null)
                throw new DuplicateProductNameException(product.Name);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> ListAsync()
        {
            var products = await _repository.GetAllAsync();
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Price = _pricingStrategy.CalculatePrice(products[i]);
            }

            return products;
        }
        public async Task<Product> UpdateAsync(Product product)
        {
            if (await _repository.GetByCodeAsync(product.Code, product.Id) != null)
                throw new DuplicateProductCodeException(product.Code);
            if (await _repository.GetByNameAsync(product.Name, product.Id) != null)
                throw new DuplicateProductNameException(product.Name);
            var entity = await _repository.GetByIdAsync(product.Id);
            if (entity == null)
                throw new EntityNotFoundException(product.Id);
            entity.Code = product.Code;
            entity.Name = product.Name;
            entity.Price = _pricingStrategy.CalculatePrice(product);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new EntityNotFoundException(id);
            _repository.Remove(entity);
            return await _repository.SaveChangesAsync();
        }
        public async Task<Product> GetAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return null;
            product.Price = _pricingStrategy.CalculatePrice(product);
            return product;
        }
    }
}
