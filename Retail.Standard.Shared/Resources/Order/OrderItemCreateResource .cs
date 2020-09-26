
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources.Order
{
    public class OrderItemCreateResource : CreateResource
    {
        [Required]
        [StringLength(37)]
        public string ProductId { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Quantity { get; set; }
    }
}
