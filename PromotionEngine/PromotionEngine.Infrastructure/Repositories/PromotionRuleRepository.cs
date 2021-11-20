using System.Collections.Generic;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Infrastructure.Repositories
{
    public class PromotionRuleRepository : IPromotionRuleRepository
    {
        private IPromotionRuleFactory promotionRuleFactory;

        public PromotionRuleRepository(IPromotionRuleFactory promotionRuleFactory)
        {
            this.promotionRuleFactory = promotionRuleFactory;
        }

        public PromotionRule GetPromotionRules()
        {
            var data = new List<(string ruleId, char[] skus, decimal value)>()
            {
                ("XOfAKind", new char[] { 'C', 'D' }, 30),
                ("XOfAKind", new char[] { 'B', 'B' }, 45),
                ("XOfAKind", new char[] { 'A', 'A', 'A' }, 130)
            };

            PromotionRule currentRule = null;

            foreach (var item in data)
            {
                currentRule = promotionRuleFactory.Create(item, currentRule);
            }

            return currentRule;
        }
    }
}
