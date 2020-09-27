using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Standard.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Web.Controllers;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : RestController<ProductCreateResource, ProductResource>
    {
        [HttpGet("search/{descriptionOrBarcode}")]
        public async Task<ActionResult<IEnumerable<ProductResource>>> Search(string descriptionOrBarcode)
        {
            return await (Application as IProductsApplication).GetByDescription(descriptionOrBarcode);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string categoryId)
        {
            return await (Application as IProductsApplication).GetByCategory(categoryId);
        }
    }
}