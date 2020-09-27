using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;

namespace Retail.Tests.RestResourcesCreators
{
    public class ProductResourceCreator :
        RestResourceCreator<ProductCreateResource, ProductResource>
    {
        public override void SetCreateResource(ProductCreateResource createResource)
        {
            base.SetCreateResource(createResource);
            createResource.DepartmentId = GetResourceId<DepartmentResource>();
            createResource.CategoryId = GetResourceId<CategoryResource>();
            createResource.ImageUrl = "https://assets.bonappetit.com/photos/5c62e4a3e81bbf522a9579ce/16:9/w_2560,c_limit/milk-bread.jpg";
            createResource.IsWeighable = false;
        }
    }
}
