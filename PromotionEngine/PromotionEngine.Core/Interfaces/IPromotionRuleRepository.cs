using PromotionEngine.Core.PromotionRules;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPromotionRuleRepository
    {
        PromotionRule GetPromotionRules();
    }
}
