using Core.Server.Client.Clients;
using Retail.Client.Interfaces;
using Retail.Shared.Resources;

namespace Retail.Client.Clients
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
