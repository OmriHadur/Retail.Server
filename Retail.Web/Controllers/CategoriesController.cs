using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;

namespace Retail.Web.Controllers
{
    [Route("api/departments/{parentId}/categories")]
    [ApiController]
    public class CategoriesController : InnerRestController<CategoryCreateResource, CategoryResource>
    {
    }
}
