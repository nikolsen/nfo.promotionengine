using System;
using PromotionEngine.Core.Interfaces;
using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Infrastructure.Factories
{
    public class PromotionRuleFactory : IPromotionRuleFactory
    {
        /// <summary>
        /// Create an instance of a rule by a provided id using the provided data item values.
        /// </summary>
        /// <param name="dataItem">A data item containing the values to assign to the rule.</param>
        /// <param name="next">The promotion rule to attach as the next rule to apply.</param>
        /// <returns>An instance of af promotion rule.</returns>
        /// <exception cref="NotImplementedException">An exception is raised if no rule is found for provided rule id.</exception>
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
