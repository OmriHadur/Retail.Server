using Retail.Standard.Shared;
using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class ProductEntity : Entity
    {
        [StringLength(20)]
        public string Description { get; set; }

        [StringLength(20)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(13)]
        public string Barcode { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Size { get; set; }

        public string SizeDisplay { get; set; }

        [Required]
        public bool IsWeighable { get; set; }

        [Required]
        public bool IsInGrams { get; set; }

        [Required]
        [Range(100, 1000)]
        public int QuantityInterval { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string CategoryId { get; set; }

        public string DepartmentName { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductEntity)
                return (obj as ProductEntity).Id == Id;
            return base.Equals(obj);
        }
    }
}
