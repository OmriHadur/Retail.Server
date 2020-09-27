using Core.Server.Client.Interfaces;
using Retail.Shared.Resources;

namespace Retail.Client.Interfaces
{
    public interface IAddressesControllClient : IInnerRestClient<AddressCreateResource, AddressResource>
    {
    }
}
