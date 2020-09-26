using Core.Server.Client.Clients;
using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Clients
{
    public class AddressesControllClient :
        InnerRestClient<AddressCreateResource, AddressResource>,
        IAddressesControllClient
    {
        public AddressesControllClient()
            :base("users/{0}/addresses")
        {
        }
    }
}
