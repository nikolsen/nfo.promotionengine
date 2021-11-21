using PromotionEngine.Core.Models;
using System.Collections.Generic;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPromotionService
    {
        decimal CalculateOrderTotal(Order order);
        IEnumerable<SKUPrice> GetAllPrices();
    }
}
