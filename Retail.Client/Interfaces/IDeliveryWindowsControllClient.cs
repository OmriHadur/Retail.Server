using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Client.Interfaces
{
    public interface IDeliveryWindowsControllClient
        : IRestClient<DeliveryWindowCreateResource, DeliveryWindowResource>
    {
        Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted();
    }
}
