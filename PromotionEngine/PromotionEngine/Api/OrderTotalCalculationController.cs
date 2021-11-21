using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTotalCalculationController : ControllerBase
    {
        private readonly IPromotionService promotionService;

        public OrderTotalCalculationController(IPromotionService promotionService)
        {
            this.promotionService = promotionService;
        }

        [HttpGet]
        public decimal Get(string skus)
        {
            // Get sanitized list of provided skus => remove unavailable items.
            var items = skus.Split(',').ToList();
            var prices = promotionService.GetAllPrices().ToList();

            if (items.Any(item => !prices.Exists(p => p.Id.ToString() == item)))
            {
                throw new ArgumentException("One or more items in the provided list not available.");
            }

            var order = new Order(items.ConvertAll(sku => sku.First()));
            var result = promotionService.CalculateOrderTotal(order);

            return result;
        }
    }
}
