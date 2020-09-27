using Core.Server.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : RestController<CartCreateResource, CartResource>
    {
        [Authorize]
        [HttpGet("my")]
        public virtual async Task<ActionResult<CartResource>> GetMyCart()
        {
            Application.CurrentUser = GetUser();
            return await (Application as ICartsApplication).GetMyCart();
        }

        [HttpPost("getorcreate")]
        public async Task<ActionResult<CartResource>> GetOrCreate(CartCreateResource createResource)
        {
            Application.CurrentUser = GetUser();
            return await (Application as ICartsApplication).GetOrCreate(createResource);
        }

        [Authorize]
        [HttpPut("{cartId}/assign")]
        public async Task<ActionResult<CartResource>> Assign(string cartId)
        {
            Application.CurrentUser = GetUser();
            return await (Application as ICartsApplication).Assign(cartId);
        }

        [HttpPut("{cartId}/addorder/{orderId}")]
        public async Task<ActionResult<CartResource>> AddOrder(string cartId,string orderId)
        {
            return await (Application as ICartsApplication).AddOrder(cartId,orderId);
        }
    }
}