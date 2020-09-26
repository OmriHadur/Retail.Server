using Retail.Common.Entities;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface ICartsRepository : IRepository<CartEntity>
    {
        Task<CartEntity> GetByUserId(string userId);
    }
}
