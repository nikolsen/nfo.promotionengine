using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public abstract class PromotionRule
    {
        public PromotionRule Next { get; }

        public PromotionRule(PromotionRule next)
        {
            Next = next;
        }

        /// <summary>
        /// Apply promotion rule on the provided list of SKUs
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public abstract RuleCalculationResult ApplyRule(ref List<char> cart);
    }
}
