
namespace Retail.Standard.Shared.Resources
{
    public class DepartmentResource : Resource
    {
        public string Name { get; set; }

        public CategoryFamily[] Families;
    }
}
