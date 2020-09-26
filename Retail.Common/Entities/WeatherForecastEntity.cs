
using System;

namespace Retail.Common.Entities
{
    public class WeatherForecastEntity : Entity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

    }
}
