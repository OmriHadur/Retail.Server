using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;

namespace Retail.Tests.RestResourcesCreators
{
    public class CartItemResourceCreator : InnerRestResourceCreator<CartItemCreateResource, CartItemResource, CartResource>
    {
        public override CartItemCreateResource GetRandomCreateResource()
        {
            var createResource = base.GetRandomCreateResource();
            createResource.ProductId = GetResourceId<ProductResource>();
            return createResource;
        }
    }
}
