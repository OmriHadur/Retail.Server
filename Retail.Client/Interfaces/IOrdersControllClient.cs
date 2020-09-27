using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Client.Interfaces
{
    public interface IOrdersControllClient : IRestClient<OrderCreateResource, OrderResource>
    {
        Task<ActionResult<IEnumerable<OrderResource>>> GetMyOrders();
        Task<ActionResult<IEnumerable<OrderResource>>> GetPendingOrdered();
        Task<ActionResult<OrderResource>> SetOrderShipped(string orderId);
    }
}
