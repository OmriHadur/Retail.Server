using Newtonsoft.Json;
using System.Collections.Generic;

namespace Retail.Standard.Shared.Resources.Cart
{
    public class CartResource : Resource
    {
        public Price CartPrice { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<CartItemResource> Items { get; set; }
    }
}
