using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Common;
using Retail.Standard.Shared.Resources;

namespace Retail.Application.Application
{
    [Inject]
    public class DepartmentsApplication : RestApplication<DepartmentCreateResource, DepartmentResource, DepartmentEntity>, IDepartmentsApplication
    {

    }
}
