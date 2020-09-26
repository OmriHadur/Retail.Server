using Retail.Common.Entities;
using Retail.Standard.Shared.Resources.Cart;
using System;
using System.Linq;

namespace Retail.Application.Mapping
{
    public class CartResourcesMappiing : MappingBase
    {
        public void AddMapping(MappingBase mappingBase)
        {
            mappingBase.AddMapping<CartCreateResource, CartResource, CartEntity>();

            mappingBase.CreateMap<CartItemCreateResource, CartItemEntity>();

            mappingBase.CreateMap<ProductEntity, CartItemEntity>();

            mappingBase.CreateMap<CartEntity, CartResource>()
                .ForPath(cr => cr.CartPrice.TotalPrice, opt => opt.MapFrom(ce => ce.Items.Sum(ci => ci.TotalPrice)))
                .ForPath(cr => cr.CartPrice.BeforeDiscount, opt => opt.MapFrom(ce => ce.Items.Sum(ci => ci.TotalPriceBeforeDiscount)))
                .ForPath(cr => cr.CartPrice.HasDiscount, opt => opt.MapFrom(ce => ce.Items.Any(ci => ci.Promotion != null)))
                .ForMember(cr => cr.Quantity, opt => opt.MapFrom(ce => ce.Items.Sum(ci => Quantity(ci))));

            mappingBase.CreateMap<CartItemEntity, CartItemResource>()
                .ForPath(cir => cir.ItemPrice.PricePerItem, opt => opt.MapFrom(ci => ci.Price))
                .ForPath(cir => cir.ItemPrice.TotalPrice, opt => opt.MapFrom(ci => ci.TotalPrice))
                .ForPath(cir => cir.ItemPrice.HasDiscount, opt => opt.MapFrom(ci => ci.Promotion != null))
                .ForPath(cir => cir.ItemPrice.BeforeDiscount, opt => opt.MapFrom(ci => ci.TotalPriceBeforeDiscount))
                .ForMember(cir => cir.SizeDisplay, opt => opt.MapFrom(ci => SizeDisplay(ci.Size,ci.IsInGrams)))
                .ForMember(cir => cir.QuantityDisplay, opt => opt.MapFrom(ci => DisplayedQuantity(ci, mappingBase)));

            mappingBase.CreateMap<CartItemPromotion, PromotionEntity>()
                .ForMember(te => te.Id, opt => opt.MapFrom(tr => tr.PromotionId));

            mappingBase.CreateMap<CartItemPromotion, CartItemPromotionResource>()
                .ForMember(te => te.Id, opt => opt.MapFrom(tr => tr.PromotionId))
                .ForMember(te => te.Discount, opt => opt.MapFrom(tr => tr.Discount));

            mappingBase.CreateMap<PromotionEntity, CartItemPromotion>()
                .ForMember(te => te.PromotionId, opt => opt.MapFrom(tr => tr.Id));
        }

        private static int Quantity(CartItemEntity ci)
        {
            return ci.IsWeighable ? (ci.Quantity > 0 ? 1 : 0) : ci.Quantity;
        }

        private static string DisplayedQuantity(CartItemEntity ci, MappingBase mappingBase)
        {
            if (!ci.IsWeighable)
                return ci.Quantity.ToString();
            var quantityDisplayed = ci.Quantity < 1000 ? ci.Quantity : Math.Round((decimal)ci.Quantity / 1000, 1);
            return mappingBase.ShortUom(quantityDisplayed, ci.Quantity, ci.IsInGrams);
        }
    }
}