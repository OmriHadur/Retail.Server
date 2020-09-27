using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources.Cart
{
    public class CartItemPromotionResource : Resource
    {
        public string Description { get; set; }

        public decimal Discount { get; set; }
    }
}
