using System.Collections.Generic;
using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources.Cart
{
    public class CartResource : Resource
    {
        public Price CartPrice { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<CartItemResource> Items { get; set; }
    }
}
