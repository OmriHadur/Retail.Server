using Retail.Standard.Client.Results;
using Retail.Standard.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Interfaces
{
    public interface IDeliveryWindowsControllClient
        : IRestClient<DeliveryWindowCreateResource, DeliveryWindowResource>
    {
        Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted();
    }
}
