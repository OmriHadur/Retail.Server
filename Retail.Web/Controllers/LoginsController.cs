using Microsoft.AspNetCore.Mvc;
using Retail.Common.Applications;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Unity;
using Microsoft.Extensions.Options;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginsController : RestController<LoginCreateResource, LoginResource>
    {
        public async override Task<ActionResult<LoginResource>> Create(LoginCreateResource createResource)
        {
            var resource = await base.Create(createResource);
            Response.Headers.Add("Authorization", "Bearer " + resource.Value?.Token);
            return resource;
        }
    }
}
