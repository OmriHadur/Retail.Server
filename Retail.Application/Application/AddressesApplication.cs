using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using Unity;
using System.Collections.Generic;
using Core.Server.Common;
using Core.Server.Application;
using Core.Server.Common.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retail.Common.Repositories;

namespace Retail.Application.Application
{
    [Inject]
    public class AddressApplication : RestApplication<AddressCreateResource, AddressResource, AddressEntity>, IAddressesApplication
    {
        public async Task<ActionResult<IEnumerable<AddressResource>>> GetMyAddresses()
        {
            var addresses = await (Repository as IAddressesRepository).GetMyAddresses(CurrentUser.Id);
            return MapMany(addresses);
        }

        protected async override Task<ActionResult> Validate(AddressCreateResource createResource)
        {
            if (!(await IsEntityExists<UserEntity>(createResource.UserId)))
                return NotFound(createResource.UserId);
            if (createResource.UserId != CurrentUser.Id)
                return new UnauthorizedResult();
            return await base.Validate(createResource);
        }
    }
}
