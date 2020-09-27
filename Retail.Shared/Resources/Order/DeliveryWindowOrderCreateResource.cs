using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources.Order
{
    public class DeliveryWindowOrderCreateResource: CreateResource
    {
        public string OrderId { get; set; }
    }
}
