using System.ComponentModel.DataAnnotations;
using Core.Server.Shared.Resources;

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
