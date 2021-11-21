using PromotionEngine.Core.Models;
using System.Collections.Generic;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPriceRepository
    {
        IEnumerable<SKUPrice> GetAllPrices();
    }
}
