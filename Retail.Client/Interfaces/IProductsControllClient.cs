using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Client.Interfaces
{
    public interface IProductsControllClient : IRestClient<ProductCreateResource, ProductResource>
    {
        Task<ActionResult<IEnumerable<ProductResource>>> Search(string descriptionOrBarcode);

        Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string CategoryId);
    }
}
