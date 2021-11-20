using System;
using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public class PromotionRuleXOfAKind : PromotionRule
    {
        public PromotionRuleXOfAKind(PromotionRule next, decimal price, params char[] args) : base(next) { }

        public override RuleCalculationResult ApplyRule(List<char> cart)
        {
            // TODO: Implement rule

            return new RuleCalculationResult(0, Next);
        }
    }
}
