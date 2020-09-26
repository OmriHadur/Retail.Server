using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Clients
{
    public class DepartmentsControllClient : 
        RestClient<DepartmentCreateResource, DepartmentResource>,
        IDepartmentsControllClient
    {
        public DepartmentsControllClient() 
            :base( "departments")
        {
        }
    }
}
