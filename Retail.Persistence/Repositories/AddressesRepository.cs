using Retail.Common.Entities;
using Retail.Common.Repositories;
using Core.Server.Persistence.Repositories;
using Core.Server.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Retail.Shared.Resources;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class AddressesRepository : MongoRepository<AddressEntity>, IAddressesRepository
    {
        public async Task<IEnumerable<AddressEntity>> GetMyAddresses(string userId)
        {
            return await Find(adress => adress.UserId == userId);
        }
    }
}