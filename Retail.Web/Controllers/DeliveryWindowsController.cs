using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Web.Controllers;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryWindowsController : RestController<DeliveryWindowCreateResource, DeliveryWindowResource>
    {
        [HttpGet("sorted")]
        public async Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted()
        {
            return await (Application as IDeliveryWindowsApplication).GetSorted();
        }
    }
}