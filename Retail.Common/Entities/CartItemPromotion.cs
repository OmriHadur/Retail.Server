using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class CartItemPromotion
    {
        public string PromotionId { get; set; }

        public decimal Discount { get; set; }
    }
}
