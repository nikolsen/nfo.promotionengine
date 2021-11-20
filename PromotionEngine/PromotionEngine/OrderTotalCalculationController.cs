using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.Models;
using System.Collections.Generic;

namespace PromotionEngine
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
        public decimal Get()
        {
            var order = new Order(new List<char> { 'A', 'A' });
            promotionService.CalculateOrderTotal(order);

            return 0;
        }
    }
}
