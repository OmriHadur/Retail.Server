using Core.Server.Common.Repositories;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface IAddressesRepository : IRepository<AddressEntity>
    {
        Task<IEnumerable<AddressEntity>> GetMyAddresses(string id);
    }
}
