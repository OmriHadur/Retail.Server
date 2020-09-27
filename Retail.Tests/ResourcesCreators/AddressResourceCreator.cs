using Core.Server.Shared.Resources.Users;
using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources;

namespace Retail.Tests.RestResourcesCreators
{
    public class AddressResourceCreator :
        InnerRestResourceCreator<AddressCreateResource, AddressResource, UserResource>
    {
    }
}
