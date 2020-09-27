using Core.Server.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Retail.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : RestController<AddressCreateResource, AddressResource>
    {
        [Authorize]
        [HttpGet("my")]
        public virtual Task<ActionResult<IEnumerable<AddressResource>>> GetMyAddresses()
        {
            Application.CurrentUser = GetUser();
            return (Application as IAddressesApplication).GetMyAddresses();
        }
    }
}