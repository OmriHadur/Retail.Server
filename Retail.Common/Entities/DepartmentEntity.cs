using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.Server.Common.Entities;

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

        public bool HasCategory(string categoryId)
        {
            return CategoriesByFamily.Values.Any(c => c.Any(cc => cc.Id == categoryId));
        }
    }
}
