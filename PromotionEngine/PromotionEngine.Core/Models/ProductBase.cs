namespace PromotionEngine.Core.Models
{
    public abstract class ProductBase
    {
        public char SKU { get; }
        public decimal Price { get; }

        protected ProductBase(char sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
