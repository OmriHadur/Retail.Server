using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Clients
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