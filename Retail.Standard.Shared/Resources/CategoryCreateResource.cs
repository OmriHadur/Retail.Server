
using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources
{
    public class CategoryCreateResource : CreateResource
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FamilyName { get; set; }
    }
}
