
using Retail.Standard.Shared.Resources;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface ICategoriesApplication : IInnerRestApplication<CategoryCreateResource, CategoryResource>
    {
    }
}
