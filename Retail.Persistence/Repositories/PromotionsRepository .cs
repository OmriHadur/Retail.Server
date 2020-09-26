using System.Threading.Tasks;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using Unity;
using Core.Server.Persistence.Repositories;
using Core.Server.Common;

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