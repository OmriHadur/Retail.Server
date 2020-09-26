using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class DepartmentEntity : Entity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public Dictionary<string, ICollection<CategoryEntity>> CategoriesByFamily { get; set; }

        public DepartmentEntity()
        {
            CategoriesByFamily = new Dictionary<string, ICollection<CategoryEntity>>();
        }
    }
}
