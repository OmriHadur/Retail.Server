using Core.Server.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Retail.Shared.Resources
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
