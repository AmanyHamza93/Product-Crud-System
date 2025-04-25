using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;

namespace Plugin.Application.Strategies
{
    public class DiscountPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountPercent;
        public DiscountPricingStrategy() => _discountPercent = 15;

        public decimal CalculatePrice(Product p) => p.Price * (1 - _discountPercent / 100);
    }
}
