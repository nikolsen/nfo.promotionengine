using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Infrastructure.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        /// <summary>
        /// Get prices for all SKUs in the system.
        /// </summary>
        /// <returns>A list of price items for SKUs.</returns>
        public IEnumerable<SKUPrice> GetAllPrices()
        {
            // Mocked data structure with prices fetched from a data source.
            var dataFromDB = new Dictionary<char, decimal>()
            {
                { 'A', 50 },
                { 'B', 30 },
                { 'C', 20 },
                { 'D', 15 }
            };

            return dataFromDB.Select(kv => new SKUPrice(kv.Key, kv.Value));
        }
    }
}
