
using System.ComponentModel.DataAnnotations;
using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources.Order
{
    public class OrderCreateResource : CreateResource
    {
        [Required]
        [StringLength(37)]
        public string CartId { get; set; }

        [Required]
        [StringLength(37)]
        public string DeliveryWindowId { get; set; }

        [Required]
        [StringLength(37)]
        public string AddressId { get; set; }
    }
}