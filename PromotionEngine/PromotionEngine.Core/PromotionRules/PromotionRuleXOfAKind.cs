using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public class PromotionRuleXOfAKind : PromotionRule
    {
        private readonly char[] _includedSKUs;
        private readonly decimal _price;

        public PromotionRuleXOfAKind(PromotionRule next, decimal price, params char[] skus) : base(next) {
            _includedSKUs = skus;
            _price = price;
        }

        /// <summary>
        /// Applies the rule defined by a any given combination of SKUs present in the provided list of SKUs.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public override RuleCalculationResult ApplyRule(ref List<char> cart)
        {
            var tempCart = cart.Select(s => s).ToList();

            foreach(var sku in _includedSKUs)
            {
                // Removes first occurence of sku in question.
                tempCart.Remove(sku);
            }

            // When all skus included in this rule have been removed from tempCart, there is match.
            var isMatch = tempCart.Count == cart.Count - _includedSKUs.Length;
            cart = isMatch ? tempCart : cart;
            
            return new RuleCalculationResult(isMatch, isMatch ? _price : 0);
        }
    }
}
