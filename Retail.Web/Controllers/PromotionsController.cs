using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;

namespace Retail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : RestController<PromotionCreateResource, PromotionResource>
    {

    }
}