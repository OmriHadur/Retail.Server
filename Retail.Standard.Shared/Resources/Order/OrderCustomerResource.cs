using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources.Order
{
    public class OrderCustomerResource : Resource
    {
        public AddressResource Address { get; set; }
        public string FullName { get; set; }
    }
}