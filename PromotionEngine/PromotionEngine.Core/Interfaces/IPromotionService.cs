using PromotionEngine.Core.Models;

namespace PromotionEngine.Core.Interfaces
{
    public interface IPromotionService
    {
        void AddProducts(params ProductBase[] args);
    }
}
