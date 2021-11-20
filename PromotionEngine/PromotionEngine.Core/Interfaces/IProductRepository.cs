using PromotionEngine.Core.Models;
using System.Collections.Generic;

namespace PromotionEngine.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductBase> GetProducts();
    }
}
