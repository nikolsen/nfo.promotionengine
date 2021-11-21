namespace PromotionEngine.Core.Models
{
    public struct SKUPrice
    {
        public char Id { get; }
        public decimal Price { get; }

        public SKUPrice(char id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}
