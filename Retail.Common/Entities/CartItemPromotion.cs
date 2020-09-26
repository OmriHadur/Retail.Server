using System.ComponentModel.DataAnnotations;
using Core.Server.Common.Entities;

namespace Retail.Common.Entities
{
    public class CartItemPromotion
    {
        public string PromotionId { get; set; }

        public decimal Discount { get; set; }
    }
}
