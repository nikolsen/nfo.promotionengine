using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Core.Models
{
    public class RuleCalculationResult
    {
        public PromotionRule NextRule { get; }

        public decimal Price { get; }

        public RuleCalculationResult(decimal price, PromotionRule nextRule)
        {
            Price = price;
            NextRule = nextRule;
        }
    }
}
