using Retail.Standard.Shared.Resources.Order;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface IDeliveryWindowOrdersApplication : IInnerRestApplication<DeliveryWindowOrderCreateResource, DeliveryWindowOrderResource>
    {
    }
}
