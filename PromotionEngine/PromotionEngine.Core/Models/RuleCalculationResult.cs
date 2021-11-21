using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Core.Models
{
    public class RuleCalculationResult
    {
        public bool Match { get; }
        public PromotionRule NextRule { get; }
        public decimal Price { get; }

        public RuleCalculationResult(bool match, decimal price, PromotionRule nextRule)
        {
            Match = match;
            Price = price;
            NextRule = nextRule;
        }
    }
}
