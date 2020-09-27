using Core.Server.Client.Clients;
using Retail.Client.Interfaces;
using Retail.Shared.Resources.Order;

namespace Retail.Client.Clients
{
    public class OrderItemControllClient : 
        InnerRestClient<OrderItemCreateResource, OrderItemResource>,
        IOrderItemsControllClient
    {
        public OrderItemControllClient()
            : base("orders/{0}/items")
        {
        }
    }
}