using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPromotionRuleFactory
    {
        PromotionRule Create((string ruleId, char[] skus, decimal value) dataItem, PromotionRule next);
    }
}
