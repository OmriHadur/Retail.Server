using Unity;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources;

namespace Retail.Application.Application
{
    [Inject]
    public class DepartmentsApplication : RestApplication<DepartmentCreateResource, DepartmentResource, DepartmentEntity>, IDepartmentsApplication
    {

    }
}
