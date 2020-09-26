using System.Threading.Tasks;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using MongoDB.Driver;
using Core.Server.Persistence.Repositories;
using Core.Server.Common;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class CartsRepository : MongoRepository<CartEntity> , ICartsRepository
    {
        public async Task<CartEntity> GetByUserId(string userId)
        {
            return (await Entities.FindAsync(e => e.CustomerId == userId)).FirstOrDefault();
        }
    }
}