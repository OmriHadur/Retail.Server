using Retail.Common.Repositories;
using System.Threading.Tasks;

namespace Retail.Common
{
    public interface IUnitOfWork
    {
        IWeatherForecastsRepository TodoRepository { get; set; }

        Task<int> Complete();
    }
}
