
namespace Retail.Shared.Resources.Cart
{
    public class Price
    {
        public decimal TotalPrice { get; set; }
        public decimal BeforeDiscount { get; set; }
        public bool HasDiscount { get; set; }
    }
}
