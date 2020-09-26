using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Standard.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

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