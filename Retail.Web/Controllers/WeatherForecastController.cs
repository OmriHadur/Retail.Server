using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;

namespace Retail.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class WeatherForecastController : RestController<WeatherForecastCreateResource, WeatherForecastResource>
    {
    }
}
