using Core.Server.Client.Interfaces;
using Retail.Shared.Resources.Order;

namespace Retail.Client.Interfaces
{
    public interface IOrderItemsControllClient : IInnerRestClient<OrderItemCreateResource, OrderItemResource>
    {
       
    }
}
