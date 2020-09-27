using Core.Server.Client.Interfaces;
using Retail.Shared.Resources;

namespace Retail.Client.Interfaces
{
    public interface ICategoriesControllClient : IInnerRestClient<CategoryCreateResource, CategoryResource>
    {

    }
}
