
using Retail.Common.Entities;
using Retail.Common.Repositories;
using System.Threading.Tasks;
using Retail.Common;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class UsersRepository : MongoRepository<UserEntity>, IUsersRepository
    {
        public async Task<bool> EmailExists(string email)
        {
            return await GetByEmail(email) != null;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await FindFirst(le => le.Email == email);
        }
    }
}