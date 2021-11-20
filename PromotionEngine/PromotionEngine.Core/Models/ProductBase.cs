namespace PromotionEngine.Core.Models
{
    public abstract class ProductBase
    {
        public string SKU { get; }
        public decimal Price { get; }

        protected ProductBase(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
