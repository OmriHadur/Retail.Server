using Retail.Client.Interfaces;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Client.Clients;
using Core.Server.Client.Results;

namespace Retail.Client.Clients
{
    public class OrdersControllClient :
        RestClient<OrderCreateResource, OrderResource>,
        IOrdersControllClient
    {
        public OrdersControllClient()
            :base("orders")
        {
        }

        public Task<ActionResult<IEnumerable<OrderResource>>> GetMyOrders()
        {
            return GetAsync<IEnumerable<OrderResource>>(ApiUrl + "my");
        }

        public Task<ActionResult<IEnumerable<OrderResource>>> GetPendingOrdered()
        {
            return GetAsync<IEnumerable<OrderResource>>(ApiUrl + "pending");
        }

        public Task<ActionResult<OrderResource>> SetOrderShipped(string orderId)
        {
            return PutAsync<OrderResource>(ApiUrl + orderId + "/shipped", null);
        }
    }
}
