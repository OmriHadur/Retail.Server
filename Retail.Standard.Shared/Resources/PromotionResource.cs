using Newtonsoft.Json;

namespace Retail.Standard.Shared.Resources
{
    public class PromotionResource : Resource
    {
        public ProductResource Product { get; set; }

        public string Description { get; set; }

        public int TriggeringQuantity { get; set; }

        public int DiscountPercentage { get; set; }

        public bool IsReApply { get; set; }
    }
}
