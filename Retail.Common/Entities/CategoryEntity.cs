using System.ComponentModel.DataAnnotations;
using Core.Server.Common.Entities;

namespace Retail.Common.Entities
{
    public class CategoryEntity : Entity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
