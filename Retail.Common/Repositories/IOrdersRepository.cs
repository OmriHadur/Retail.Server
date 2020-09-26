using Retail.Common.Entities;
using Retail.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface IOrdersRepository : IRepository<OrderEntity>
    {
        Task<List<OrderEntity>> GetAllByCustomer(string userId);
        Task<List<OrderEntity>> GetAllByStats(eOrderStatus ordered);
    }
}
