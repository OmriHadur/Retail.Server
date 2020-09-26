using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources.Cart;
using Retail.Standard.Shared.Resources.Order;

namespace Retail.Web.Controllers
{
    [Route("api/orders/{parentId}/items")]
    [ApiController]
    public class OrderItemsController : InnerRestController<OrderItemCreateResource, OrderItemResource>
    {

    }
}
