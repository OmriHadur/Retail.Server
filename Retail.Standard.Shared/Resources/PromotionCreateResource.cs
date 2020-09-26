using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources
{
    public class PromotionCreateResource : CreateResource
    {
        [Required]
        public string ProductId { get; set; }

        [StringLength(20)]
        public string Description { get; set; }

        [Required]
        [Range(1, 99)]
        public int TriggeringQuantity { get; set; }

        [Required]
        [Range(1, 100)]
        public int DiscountPercentage { get; set; }

        public bool IsReApply { get; set; }
    }
}
