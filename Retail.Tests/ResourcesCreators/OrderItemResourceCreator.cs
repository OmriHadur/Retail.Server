using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Order;

namespace Retail.Tests.RestResourcesCreators
{
    public class OrderItemResourceCreator :
       InnerRestResourceCreator<OrderItemCreateResource, OrderItemResource, OrderResource>
    {
        public override OrderItemCreateResource GetRandomCreateResource()
        {
            var createResource = base.GetRandomCreateResource();
            createResource.ProductId = ResourcesHolder.Create<ProductResource>().Value.Id;
            return createResource;
        }
    }
}
