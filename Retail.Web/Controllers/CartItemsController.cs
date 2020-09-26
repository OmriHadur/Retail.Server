using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Web.Controllers
{
    [Route("api/carts/{parentId}/items")]
    [ApiController]
    public class CartItemsController : InnerRestController<CartItemCreateResource, CartItemResource>
    {
        [HttpPost("scan")]
        public virtual async Task<ActionResult<CartItemResource>> Scan(string parentId, CartItemCreateScanResource resource)
        {
            Application.CurrentUser = GetUser();
            return await (Application as ICartItemsApplication).Scan(parentId, resource);
        }
    }
}
