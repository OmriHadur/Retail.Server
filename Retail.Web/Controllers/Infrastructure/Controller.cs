using Retail.Common.Entities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Unity;
using Retail.Standard.Shared.Errors;
using Retail.Standard.Shared.Resources.Users;
using Retail.Common.Errors;

namespace Retail.Web.Controllers
{
    public class Controller : ControllerBase
    {
        [Dependency]
        public IJwtManager JwtManager { get; set; }

        protected ActionResult BadRequest(BadRequestReason badRequestReason)
        {
            return new BadRequestApplicationResult(badRequestReason);
        }

        protected UserResource GetUser()
        {
            return JwtManager.GetUser(User);
        }
    }
}
