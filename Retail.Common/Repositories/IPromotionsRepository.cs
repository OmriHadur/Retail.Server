using System.Collections.Generic;
using System.Threading.Tasks;
using Retail.Common.Entities;

namespace Retail.Common.Repositories
{
    public interface IPromotionsRepository : IRepository<PromotionEntity>
    {
        Task<PromotionEntity> GetByProductId(string productId);
    }
}
