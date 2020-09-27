using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources
{
    public class DepartmentResource : Resource
    {
        public string Name { get; set; }

        public CategoryFamily[] Families;
    }
}
