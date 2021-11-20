using System;
using Xunit;

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
            throw new NotImplementedException();
        }

        [Fact]
        public void Calculate_Total_With_Rules_Applied_For_A_And_B()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Calculate_Total_With_All_Rules_Applied()
        {
            throw new NotImplementedException();
        }
    }
}
