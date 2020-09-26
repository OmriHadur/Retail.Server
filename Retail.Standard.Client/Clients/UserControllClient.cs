using System.Net.Http;
using System.Threading.Tasks;
using Retail.Standard.Client.Interfaces;
using Retail.Standard.Client.Results;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Standard.Client.Clients
{
    public class UserControllClient : 
        RestClient<UserCreateResource, UserResource>,
        IUserControllClient
    {
        public UserControllClient()
            :base("users")
        {
        }
    }
}
