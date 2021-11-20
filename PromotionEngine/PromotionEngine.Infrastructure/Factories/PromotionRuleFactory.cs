using System;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Infrastructure.Factories
{
    public class PromotionRuleFactory : IPromotionRuleFactory
    {
        public PromotionRule Create((string ruleId, char[] skus, decimal value) dataItem, PromotionRule next)
        {
            if(dataItem.ruleId == "XOfAKind")
            {
                return new PromotionRuleXOfAKind(next, dataItem.value, dataItem.skus);
            }

            throw new NotImplementedException($"Rule: {dataItem.ruleId} not handled.");
        }
    }
}
