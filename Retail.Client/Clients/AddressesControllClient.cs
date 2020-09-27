using Core.Server.Client.Clients;
using Retail.Client.Interfaces;
using Retail.Shared.Resources;

namespace Retail.Client.Clients
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
