using Retail.Common.Entities;
using Retail.Common.Repositories;
using Retail.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using Retail.Common.Enums;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class OrdersRepository : MongoRepository<OrderEntity>, IOrdersRepository
    {
        public async Task<List<OrderEntity>> GetAllByCustomer(string userId)
        {
            var filter = Builders<OrderEntity>.Filter.Eq(x => x.Cart.CustomerId, userId);
            return await Entities.Find(filter).SortByDescending(o => o.Created).ToListAsync();
        }

        public async Task<List<OrderEntity>> GetAllByStats(eOrderStatus status)
        {
            var filter = Builders<OrderEntity>.Filter.Eq(x => x.Status, status);
            return await Entities.Find(filter).ToListAsync();
        }
    }
}