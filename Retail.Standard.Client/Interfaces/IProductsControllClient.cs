using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Standard.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Interfaces
{
    public interface IProductsControllClient : IRestClient<ProductCreateResource, ProductResource>
    {
        Task<ActionResult<IEnumerable<ProductResource>>> Search(string descriptionOrBarcode);

        Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string CategoryId);
    }
}
