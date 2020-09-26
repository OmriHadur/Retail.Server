using Core.Server.Client.Interfaces;
using Retail.Standard.Shared.Resources.Order;

namespace Retail.Standard.Client.Interfaces
{
    public interface IOrderItemsControllClient : IInnerRestClient<OrderItemCreateResource, OrderItemResource>
    {
       
    }
}
