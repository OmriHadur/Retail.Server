using Core.Server.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources;

namespace Retail.Web.Controllers
{
    [Route("api/users/{parentId}/addresses")]
    [ApiController]
    public class AddressesController : InnerRestController<AddressCreateResource, AddressResource>
    {
    }
}