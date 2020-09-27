using Core.Server.Client.Clients;
using Core.Server.Client.Results;
using Retail.Client.Interfaces;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Client.Clients
{
    public class DeliveryWindowsControllClient :
        RestClient<DeliveryWindowCreateResource, DeliveryWindowResource>,
        IDeliveryWindowsControllClient
    {
        public DeliveryWindowsControllClient()
            : base("deliverywindows")
        {
        }

        public Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted()
        {
            return GetAsync<Dictionary<string, DeliveryWindowResource>>($"{ApiUrl}sorted");
        }
    }
}