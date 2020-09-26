using Retail.Common.Entities;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface IUsersRepository : IRepository<UserEntity>
    {
        Task<bool> EmailExists(string email);

        Task<UserEntity> GetByEmail(string email);
    }
}
