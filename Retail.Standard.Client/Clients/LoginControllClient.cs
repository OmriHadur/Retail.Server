using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Standard.Client.Clients
{
    public class LoginControllClient : 
        RestClient<LoginCreateResource, LoginResource>,
        ILoginControllClient
    {
        public LoginControllClient()
            :base("logins")
        {
        }
    }
}
