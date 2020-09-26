
namespace Retail.Common.Entities
{
    public class CartItemEntity : Entity
    {
        public string Description { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public bool IsWeighable { get; set; }

        public bool IsInGrams { get; set; }

        public int QuantityInterval { get; set; }

        public string DepartmentName { get; set; }

        public string CompenyName { get; set; }

        public CartItemPromotion Promotion { get; set; }

        public decimal TotalPrice => TotalPriceBeforeDiscount - (Promotion?.Discount ?? 0);

        public decimal TotalPriceBeforeDiscount => (IsWeighable ? ((decimal)Quantity / Size) : Quantity) * Price;
    }
}
