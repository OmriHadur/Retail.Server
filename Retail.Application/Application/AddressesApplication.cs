using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using Retail.Common;
using Unity;
using System.Collections.Generic;
using Core.Server.Common;
using Core.Server.Application;
using Core.Server.Common.Entities;

namespace Retail.Application.Application
{
    [Inject]
    public class AddressApplication : InnerRestApplication<AddressCreateResource, AddressResource, UserEntity, AddressEntity>, IAddressesApplication
    {
        protected override ICollection<AddressEntity> GetEntities(UserEntity parent)
        {
            return null;// parent.Adresses;
        }
    }
}
