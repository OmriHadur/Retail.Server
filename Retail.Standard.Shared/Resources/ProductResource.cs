using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources
{
    public class ProductResource : Resource
    {
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Barcode { get; set; }

        public string SizeDisplay { get; set; }

        public int Size { get; set; }

        public bool IsWeighable { get; set; }

        public bool IsInGrams { get; set; }

        public int QuantityInterval { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string DepartmentName { get; set; }

        public string CategoryId { get; set; }
    }
}
