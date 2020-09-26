using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Common.Applications
{
    public interface IUsersApplication : IRestApplication<UserCreateResource, UserResource>
    {
    }
}
