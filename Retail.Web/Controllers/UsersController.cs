using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Retail.Standard.Shared.Resources.Users;
using System.Threading.Tasks;

namespace Retail.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : RestController<UserCreateResource, UserResource>
    {
        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<UserResource>> Create(UserCreateResource resource)
        {
            return await Application.Create(resource);
        }
    }
}
