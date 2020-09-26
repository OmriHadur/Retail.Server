using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;

namespace Retail.Web.Controllers
{
    [Route("api/users/{parentId}/addresses")]
    [ApiController]
    public class AddressesController : InnerRestController<AddressCreateResource, AddressResource>
    {
    }
}