using System.Collections.Generic;

namespace PromotionEngine.Core.Models
{
    public class Order
    {
        public List<char> Cart { get; }

        public Order(List<char> cart)
        {
            Cart = cart;
        }
    }
}
