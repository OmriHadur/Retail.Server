using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Interfaces
{
    public interface IAddressesControllClient : IInnerRestClient<AddressCreateResource, AddressResource>
    {
    }
}
