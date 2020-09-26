using Retail.Common.Entities;
using Retail.Common.Repositories;
using Core.Server.Persistence.Repositories;
using Core.Server.Common;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class DeliveryWindowsRepository : MongoRepository<DeliveryWindowEntity>, IDeliveryWindowsRepository
    {
    }
}