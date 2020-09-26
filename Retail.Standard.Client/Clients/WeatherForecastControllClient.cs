
using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Clients
{
    public class WeatherForecastControllClient : 
        RestClient<WeatherForecastCreateResource, WeatherForecastResource>,
        IWeatherForecastControllClient
    {
        public WeatherForecastControllClient() 
            :base("weatherforecasts")
        {
        }
    }
}
