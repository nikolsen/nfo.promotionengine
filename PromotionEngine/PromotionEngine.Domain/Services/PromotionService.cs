using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Domain.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRuleRepository promotionRuleRepository;
        private readonly IPriceRepository productRepository;

        public PromotionService(IPromotionRuleRepository promotionRuleRepository, IPriceRepository productRepository)
        {
            this.promotionRuleRepository = promotionRuleRepository;
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Calculates the total price of SKUs in a provided order.
        /// </summary>
        /// <param name="order">An instance of Order</param>
        /// <returns>The total price of the provided order.</returns>
        public decimal CalculateOrderTotal(Order order)
        {
            var currentRule = promotionRuleRepository.GetPromotionRules();

            if(currentRule == null)
            {
                return GetPriceSumOfSKUs(order.Cart);
            }

            var cart = order.Cart.Select(item => item).ToList();
            decimal total = 0;

            do
            {
                var result = currentRule.ApplyRule(ref cart);
                total += result.Price;
                currentRule = result.Match ? currentRule : currentRule.Next;
            } while (currentRule != null);

            // Add prices of remaining items in cart after rule application.
            total += GetPriceSumOfSKUs(cart);

            return total;
        }

        /// <summary>
        /// Calculates the total price of a collection of SKUs
        /// </summary>
        /// <param name="skus"></param>
        /// <returns>The total price of provided SKUs</returns>
        private decimal GetPriceSumOfSKUs(IEnumerable<char> skus)
        {
            var allPrices = productRepository.GetAllPrices();
            return skus.Sum(sku => allPrices.FirstOrDefault(i => i.Id == sku).Price);
        }
    }
}
