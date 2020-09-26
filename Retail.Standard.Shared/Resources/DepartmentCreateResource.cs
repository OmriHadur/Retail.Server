using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources
{
    public class DepartmentCreateResource : CreateResource
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
