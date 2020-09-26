using Retail.Standard.Shared.Resources.Order;

namespace Retail.Common.Applications
{
    public interface IDeliveryWindowOrdersApplication : IInnerRestApplication<DeliveryWindowOrderCreateResource, DeliveryWindowOrderResource>
    {
    }
}
