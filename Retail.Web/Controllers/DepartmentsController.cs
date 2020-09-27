using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources;
using Core.Server.Web.Controllers;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : RestController<DepartmentCreateResource, DepartmentResource>
    {

    }
}