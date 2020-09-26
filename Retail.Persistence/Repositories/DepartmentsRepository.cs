using Retail.Common;
using Retail.Common.Entities;
using Retail.Common.Repositories;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class DepartmentsRepository : MongoRepository<DepartmentEntity> , IDepartmentsRepository
    {

    }
}