using Retail.Standard.Client.Results;
using Retail.Standard.Shared.Resources.Users;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Interfaces
{
    public interface ILoginControllClient : IRestClient<LoginCreateResource, LoginResource>
    {
    }
}
