using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Client.Clients;
using Core.Server.Client.Results;

namespace Retail.Standard.Client.Clients
{
    public class ProductsControllClient :
        RestClient<ProductCreateResource, ProductResource>,
        IProductsControllClient
    {
        public ProductsControllClient()
            : base("products")
        {
        }

        public Task<ActionResult<IEnumerable<ProductResource>>> Search(string descriptionOrBarcode)
        {
            return GetAsync<IEnumerable<ProductResource>>(ApiUrl + "search/" + descriptionOrBarcode);
        }

        public Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string CategoryId)
        {
            return GetAsync<IEnumerable<ProductResource>>(ApiUrl + "Category/" + CategoryId);
        }
    }
}
