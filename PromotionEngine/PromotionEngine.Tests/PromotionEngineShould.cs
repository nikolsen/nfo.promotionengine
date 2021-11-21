using Xunit;
using System.Collections.Generic;
using PromotionEngine.Core.Models;

namespace PromotionEngine.Tests
{
    public class PromotionEngineShould : IClassFixture<PromotionEngineFixture>
    {
        private readonly PromotionEngineFixture _fixture;

        public PromotionEngineShould(PromotionEngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Calculate_Total_Without_Rules_Applied()
        {
            var order = new Order(new List<char>() { 'A', 'B', 'C' });
            var total = _fixture.PromotionService.CalculateOrderTotal(order);

            Assert.Equal(100, total);
        }

        [Fact]
        public void Calculate_Total_With_Rules_Applied_For_A_And_B()
        {
            var order = new Order(new List<char>() { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' });
            var total = _fixture.PromotionService.CalculateOrderTotal(order);

            Assert.Equal(370, total);
        }

        [Fact]
        public void Calculate_Total_With_All_Rules_Applied()
        {
            var order = new Order(new List<char>() { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });
            var total = _fixture.PromotionService.CalculateOrderTotal(order);

            Assert.Equal(280, total);
        }
    }
}
