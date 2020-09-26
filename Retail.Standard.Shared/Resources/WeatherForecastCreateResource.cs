using Newtonsoft.Json;
using System;

namespace Retail.Standard.Shared.Resources
{
    public class WeatherForecastCreateResource : CreateResource
    {
        public DateTime Date { get; set; }

        public int TemperatureInC { get; set; }

        public string Summary { get; set; }
    }
}
