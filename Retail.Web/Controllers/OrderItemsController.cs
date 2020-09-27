using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources.Order;
using Core.Server.Web.Controllers;

namespace Retail.Web.Controllers
{
    [Route("api/orders/{parentId}/items")]
    [ApiController]
    public class OrderItemsController : InnerRestController<OrderItemCreateResource, OrderItemResource>
    {

    }
}
