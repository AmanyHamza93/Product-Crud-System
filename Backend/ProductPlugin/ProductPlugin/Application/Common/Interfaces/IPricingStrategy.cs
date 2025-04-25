using Plugin.Domain.Models;

namespace Plugin.Application.Common.Interfaces
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Product p);
    }
}
