
using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources.Cart
{
    public class CartItemResource : Resource
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string QuantityDisplay { get; set; }
        public int QuantityInterval { get; set; }
        public bool IsWeighable { get; set; }
        public string SizeDisplay { get; set; }
        public string DepartmentName { get; set; }
        public CartItemPrice ItemPrice { get; set; }
    }
}
