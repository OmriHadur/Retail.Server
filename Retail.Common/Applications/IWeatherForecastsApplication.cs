
using Retail.Standard.Shared.Resources;

namespace Retail.Common.Applications
{
    public interface IWeatherForecastsApplication : IRestApplication<WeatherForecastCreateResource, WeatherForecastResource>
    {
    }
}
