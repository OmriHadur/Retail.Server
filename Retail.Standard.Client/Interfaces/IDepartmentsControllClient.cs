using Core.Server.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Interfaces
{
    public interface IDepartmentsControllClient : IRestClient<DepartmentCreateResource, DepartmentResource>
    {

    }
}
