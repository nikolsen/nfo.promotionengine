using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.PromotionRules
{
    public class PromotionRuleXOfSKUsPct : PromotionRule
    {
        private readonly char[] _includedSKUs;
        private readonly decimal _discountFactor;

        public PromotionRuleXOfSKUsPct(PromotionRule next, decimal discountFactor, params char[] skus) : base(next)
        {
            _discountFactor = discountFactor;
            _includedSKUs = skus;
        }

        /// <summary>
        /// Applies the rule of percentagewise discount for SKU combinations in the cart that matches SKUs included in current rule.
        /// </summary>
        /// <param name="cart">A collection of SKUs to examine for rule match.</param>
        /// <returns>An instance of RuleCalculationResult with indication of a match is successful. 
        /// If match i successful, the promoted price is set to value of the rule, otherwise it is set to 0.</returns>
        public override RuleCalculationResult ApplyRule(ref List<char> cart, IEnumerable<SKUPrice> allPrices)
        {
            var tempCart = cart.Select(s => s).ToList();

            foreach (var sku in _includedSKUs)
            {
                // Removes first occurence of sku in question.
                tempCart.Remove(sku);
            }

            // When all skus included in this rule have been removed from tempCart, there is match.
            var isMatch = tempCart.Count == cart.Count - _includedSKUs.Length;
            cart = isMatch ? tempCart : cart;
            
            if(isMatch)
            {
                var priceExclDiscount = _includedSKUs.Sum(sku => allPrices.First(p => p.Id == sku).Price);
                var priceInclDiscount = priceExclDiscount - priceExclDiscount * _discountFactor;
                return new RuleCalculationResult(true, priceInclDiscount);
            }

            return new RuleCalculationResult(false, 0);
        }
    }
}
