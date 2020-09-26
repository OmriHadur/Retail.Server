using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources;
using Retail.Common;
using Unity;
using System.Collections.Generic;

namespace Retail.Application.Application
{
    [Inject]
    public class AddressApplication : InnerRestApplication<AddressCreateResource, AddressResource, UserEntity, AddressEntity>, IAddressesApplication
    {
        protected override ICollection<AddressEntity> GetEntities(UserEntity parent)
        {
            return parent.Adresses;
        }
    }
}
