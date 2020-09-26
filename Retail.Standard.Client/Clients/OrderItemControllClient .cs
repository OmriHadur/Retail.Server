using Core.Server.Client.Clients;
using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources.Order;

namespace Retail.Standard.Client.Clients
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