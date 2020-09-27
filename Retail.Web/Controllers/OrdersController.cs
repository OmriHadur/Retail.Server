using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Common.Enums;
using Retail.Standard.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Web.Controllers;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : RestController<OrderCreateResource, OrderResource>
    {
        [Authorize]
        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetMyOrders()
        {
            Application.CurrentUser = GetUser();
            return await (Application as IOrdersApplication).GetMyOrders();
        }

        [Authorize]
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetPendingOrdered()
        {
            Application.CurrentUser = GetUser();
            return await (Application as IOrdersApplication).GetAllByStats(eOrderStatus.Pending);
        }

        [Authorize]
        [HttpPut("{orderId}/shipped")]
        public async Task<ActionResult<OrderResource>> SetOrderShipped(string orderId)
        {
            Application.CurrentUser = GetUser();
            return await (Application as IOrdersApplication).SetStatus(orderId,eOrderStatus.Shipped);
        }
    }
}