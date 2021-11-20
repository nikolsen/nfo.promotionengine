using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public abstract class PromotionRule
    {
        protected PromotionRule Next { get; }

        public PromotionRule(PromotionRule next)
        {
            Next = next;
        }

        public abstract RuleCalculationResult ApplyRule(List<char> cart);
    }
}
