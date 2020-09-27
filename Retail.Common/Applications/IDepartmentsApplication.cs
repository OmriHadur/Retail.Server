using Core.Server.Common.Applications;
using Retail.Shared.Resources;

namespace Retail.Common.Applications
{
    public interface IDepartmentsApplication : IRestApplication<DepartmentCreateResource, DepartmentResource>
    {
    }
}
