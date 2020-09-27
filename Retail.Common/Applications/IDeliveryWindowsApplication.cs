using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface IDeliveryWindowsApplication : IRestApplication<DeliveryWindowCreateResource, DeliveryWindowResource>
    {
        Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted();
    }
}
