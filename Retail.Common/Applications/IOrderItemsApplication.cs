using Retail.Standard.Shared.Resources.Cart;
using Retail.Standard.Shared.Resources.Order;

namespace Retail.Common.Applications
{
    public interface IOrderItemsApplication : IInnerRestApplication<OrderItemCreateResource, OrderItemResource>
    {
    }
}
