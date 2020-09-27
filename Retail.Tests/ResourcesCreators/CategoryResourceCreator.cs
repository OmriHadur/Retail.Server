using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;

namespace Retail.Tests.RestResourcesCreators
{
    public class CategoryResourceCreator :
        InnerRestResourceCreator<CategoryCreateResource, CategoryResource, DepartmentResource>
    {
    }
}
