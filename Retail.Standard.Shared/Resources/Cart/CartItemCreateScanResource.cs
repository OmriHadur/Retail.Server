using Core.Server.Shared.Resources;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources.Cart
{
    public class CartItemCreateScanResource : CreateResource
    {
        [Required]
        [MinLength(13)]
        [StringLength(13)]
        public string Barcode { get; set; }
    }
}
