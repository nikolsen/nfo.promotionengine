using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.Models;
using System.Collections.Generic;

namespace PromotionEngine.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductBase> GetProducts()
        {
            return new List<ProductBase>()
            {
                new ProductA('A', 50),
                new ProductB('B', 30),
                new ProductC('C', 20),
                new ProductD('D', 15)
            };
        }
    }
}
