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

        public decimal CalculateOrderTotal(Order order)
        {
            var cart = order.Cart;
            decimal total = 0;

            var nextRule = this.promotionRuleRepository.GetPromotionRules();

            do
            {
                var result = nextRule.ApplyRule(ref cart);
                total += result.Price;
                nextRule = result.NextRule;
            } while (nextRule != null);

            var allPrices = productRepository.GetAllPrices();
            total += cart.Sum(sku => allPrices.FirstOrDefault(i => i.Id == sku).Price);

            return total;
        }
    }
}
