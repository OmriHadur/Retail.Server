using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class PromotionEntity : Entity
    {
        [Required]
        public string ProductId { get; set; }

        [StringLength(20)]
        public string Description { get; set; }

        [Required]
        public int TriggeringQuantity { get; set; }

        [Required]
        public int DiscountPercentage { get; set; }

        public bool IsReApply { get; set; }
    }
}
