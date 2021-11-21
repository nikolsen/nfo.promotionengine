﻿using System.Collections.Generic;
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
            var currentRule = promotionRuleRepository.GetPromotionRules();

            if(currentRule == null)
            {
                return GetPriceSumOfSKUs(order.Cart);
            }

            var cart = order.Cart.Select(item => item).ToList();
            decimal total = 0;

            do
            {
                var result = currentRule.ApplyRule(ref cart);
                total += result.Price;
                currentRule = result.Match ? currentRule : currentRule.Next;
            } while (currentRule != null);

            // Add prices of remaining items in cart after rule application.
            total += GetPriceSumOfSKUs(cart);

            return total;
        }

        private decimal GetPriceSumOfSKUs(IEnumerable<char> skus)
        {
            var allPrices = productRepository.GetAllPrices();
            return skus.Sum(sku => allPrices.FirstOrDefault(i => i.Id == sku).Price);
        }
    }
}
