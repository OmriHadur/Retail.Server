using Core.Server.Common.Applications;
using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Common.Applications
{
    public interface IAddressesApplication : IRestApplication<AddressCreateResource, AddressResource>
    {
        Task<ActionResult<IEnumerable<AddressResource>>> GetMyAddresses();
    }
}
