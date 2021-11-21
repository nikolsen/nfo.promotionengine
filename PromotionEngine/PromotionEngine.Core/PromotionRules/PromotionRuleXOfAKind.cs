﻿using System.Linq;
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

        public override RuleCalculationResult ApplyRule(ref List<char> cart)
        {
            var tempCart = cart.Select(s => s).ToList();

            foreach(var sku in _includedSKUs)
            {
                // Removes first occurence of sku in question.
                tempCart.Remove(sku);
            }

            // When all skus included in this rule have been removed from tempCart, there is match.
            if (tempCart.Count == cart.Count - _includedSKUs.Length)
            {
                cart = tempCart;
                return new RuleCalculationResult(true, _price, this);
            }

            // No match.
            return new RuleCalculationResult(false, 0, Next);
        }
    }
}
