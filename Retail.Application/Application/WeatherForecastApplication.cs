using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources;
using Retail.Common;

namespace Retail.Application.Application
{
    [Inject]
    public class WeatherForecastApplication : RestApplication<WeatherForecastCreateResource, WeatherForecastResource, WeatherForecastEntity>, IWeatherForecastsApplication
    {
    }
}
