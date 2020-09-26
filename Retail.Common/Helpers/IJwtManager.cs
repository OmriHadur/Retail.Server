using Retail.Standard.Shared.Resources.Users;
using System.Security.Claims;

namespace Retail.Common.Entities.Helpers
{
    public interface IJwtManager
    {
        string GenerateToken(UserResource user,string secret);
        UserResource GetUser(ClaimsPrincipal ClaimsPrincipal);
    }
}