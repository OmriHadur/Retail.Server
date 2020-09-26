using System.Threading.Tasks;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using Retail.Common;
using Unity;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class PromotionsRepository : MongoRepository<PromotionEntity>, IPromotionsRepository
    {
        public async Task<PromotionEntity> GetByProductId(string productId)
        {
            return await FindFirst(pe => pe.ProductId == productId);
        }
    }
}