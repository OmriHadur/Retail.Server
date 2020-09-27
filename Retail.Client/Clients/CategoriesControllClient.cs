using Core.Server.Client.Clients;
using Retail.Client.Interfaces;
using Retail.Shared.Resources;

namespace Retail.Client.Clients
{
    public class CategoriesControllClient : 
        InnerRestClient<CategoryCreateResource, CategoryResource>,
        ICategoriesControllClient
    {
        public CategoriesControllClient()
            : base("departments/{0}/categories")
        {
        }
    }
}