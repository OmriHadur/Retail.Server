using Retail.Common.Entities;
using Retail.Common.Repositories;
using Retail.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class DeliveryWindowsRepository : MongoRepository<DeliveryWindowEntity>, IDeliveryWindowsRepository
    {
    }
}