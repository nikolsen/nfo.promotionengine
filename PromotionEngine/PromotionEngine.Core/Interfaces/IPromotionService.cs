using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPromotionService
    {
        decimal CalculateOrderTotal(Order order);
    }
}
