using Core.Server.Common.Applications;
using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Common.Applications
{
    public interface IProductsApplication : IRestApplication<ProductCreateResource, ProductResource>
    {
        Task<ActionResult<IEnumerable<ProductResource>>> GetByDescription(string descriptionOrBarcode);
        Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string categoryId);
    }
}
