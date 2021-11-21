using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public class PromotionRuleXOfSKUsFixed : PromotionRule
    {
        private readonly char[] _includedSKUs;
        private readonly decimal _price;

        public PromotionRuleXOfSKUsFixed(PromotionRule next, decimal price, params char[] skus) : base(next) {
            _includedSKUs = skus;
            _price = price;
        }

        /// <summary>
        /// Applies the rule defined by a any given combination of SKUs present in the provided list of SKUs.
        /// </summary>
        /// <param name="cart">A collection of SKUs to examine for rule match</param>
        /// <returns>An instance of RuleCalculationResult with indication of a match and promoted price.</returns>
        public override RuleCalculationResult ApplyRule(ref List<char> cart, IEnumerable<SKUPrice> allPrices)
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
