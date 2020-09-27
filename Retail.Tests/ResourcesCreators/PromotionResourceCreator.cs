using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;

namespace Retail.Tests.RestResourcesCreators
{
    public class PromotionResourceCreator :
        RestResourceCreator<PromotionCreateResource, PromotionResource>
    {
        public override void SetCreateResource(PromotionCreateResource createResource)
        {
            base.SetCreateResource(createResource);
            createResource.ProductId = GetResourceId<ProductResource>();
        }
    }
}
