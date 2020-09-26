using Retail.Common.Entities;
using Retail.Common.Repositories;
using Retail.Common;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class WeatherForecastsRepository : MongoRepository<WeatherForecastEntity> , IWeatherForecastsRepository
    {

    }
}