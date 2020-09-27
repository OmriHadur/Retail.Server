using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources
{
    public class ProductCreateResource : CreateResource
    {
        [StringLength(20)]
        public string Description { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string Barcode { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Size { get; set; }

        [Required]
        public bool IsWeighable { get; set; }

        [Required]
        public bool IsInGrams { get; set; }

        [Range(100, 1000)]
        public int QuantityInterval { get; set; }

        [Required]
        [Range(0.1, 99)]
        public decimal Price { get; set; }

        [Required]
        public string DepartmentId { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [StringLength(20)]
        public string CompanyName { get; set; }

        public string ImageUrl { get; set; }
    }
}
