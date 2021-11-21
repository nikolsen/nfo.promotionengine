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

        /// <summary>
        /// Get the first item in the collection of promotion rules to evaluate against. 
        /// Subsequent rules are accessed by iterating the chain using the Next property of each rule.
        /// </summary>
        /// <returns>The first instance in the chain of promotion rules.</returns>
        public PromotionRule GetPromotionRules()
        {
            var data = new List<(string ruleId, char[] skus, decimal value)>()
            {
                ("XOfSKUsFixed", new char[] { 'C', 'D' }, 30),
                ("XOfSKUsFixed", new char[] { 'B', 'B' }, 45),
                ("XOfSKUsFixed", new char[] { 'A', 'A', 'A' }, 130),
                ("XOfSKUsPct", new char[] { 'D', 'D' }, 0.1M)
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
