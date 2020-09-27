using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;
using Retail.Shared.Resources.Order;

namespace Retail.Tests.RestResourcesCreators
{
    public class OrderResourceCreator :
        RestResourceCreator<OrderCreateResource, OrderResource>
    {
        public override void SetCreateResource(OrderCreateResource createResource)
        {
            base.SetCreateResource(createResource);
            createResource.AddressId = GetResourceId<AddressResource>();
            createResource.CartId = GetResourceId<CartResource>();
            createResource.DeliveryWindowId = GetResourceId<DeliveryWindowResource>();
        }
    }
}
