using AutoMapper;
using Core.Server.Common;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources.Cart;
using System;
using System.Linq;

namespace Retail.Application.Mapping
{
    [InjectMany]
    public class CartResourcesMappiing : MappingBase
    {
        public override void AddMapping(Profile profile)
        {
            profile.CreateMap<CartEntity, CartResource>();
            profile.CreateMap<CartCreateResource, CartEntity>();

            profile.CreateMap<CartItemCreateResource, CartItemEntity>();

            profile.CreateMap<ProductEntity, CartItemEntity>();

            profile.CreateMap<CartEntity, CartResource>()
                .ForPath(cr => cr.CartPrice.TotalPrice, opt => opt.MapFrom(ce => ce.Items.Sum(ci => ci.TotalPrice)))
                .ForPath(cr => cr.CartPrice.BeforeDiscount, opt => opt.MapFrom(ce => ce.Items.Sum(ci => ci.TotalPriceBeforeDiscount)))
                .ForPath(cr => cr.CartPrice.HasDiscount, opt => opt.MapFrom(ce => ce.Items.Any(ci => ci.Promotion != null)))
                .ForMember(cr => cr.Quantity, opt => opt.MapFrom(ce => ce.Items.Sum(ci => Quantity(ci))));

            profile.CreateMap<CartItemEntity, CartItemResource>()
                .ForPath(cir => cir.ItemPrice.PricePerItem, opt => opt.MapFrom(ci => ci.Price))
                .ForPath(cir => cir.ItemPrice.TotalPrice, opt => opt.MapFrom(ci => ci.TotalPrice))
                .ForPath(cir => cir.ItemPrice.HasDiscount, opt => opt.MapFrom(ci => ci.Promotion != null))
                .ForPath(cir => cir.ItemPrice.BeforeDiscount, opt => opt.MapFrom(ci => ci.TotalPriceBeforeDiscount))
                .ForMember(cir => cir.SizeDisplay, opt => opt.MapFrom(ci => SizeDisplay(ci.Size, ci.IsInGrams)))
                .ForMember(cir => cir.QuantityDisplay, opt => opt.MapFrom(ci => DisplayedQuantity(ci)));

            profile.CreateMap<CartItemPromotion, PromotionEntity>()
                .ForMember(te => te.Id, opt => opt.MapFrom(tr => tr.PromotionId));

            profile.CreateMap<CartItemPromotion, CartItemPromotionResource>()
                .ForMember(te => te.Id, opt => opt.MapFrom(tr => tr.PromotionId))
                .ForMember(te => te.Discount, opt => opt.MapFrom(tr => tr.Discount));

            profile.CreateMap<PromotionEntity, CartItemPromotion>()
                .ForMember(te => te.PromotionId, opt => opt.MapFrom(tr => tr.Id));
        }

        private int Quantity(CartItemEntity ci)
        {
            return ci.IsWeighable ? (ci.Quantity > 0 ? 1 : 0) : ci.Quantity;
        }

        private string DisplayedQuantity(CartItemEntity ci)
        {
            if (!ci.IsWeighable)
                return ci.Quantity.ToString();
            var quantityDisplayed = ci.Quantity < 1000 ? ci.Quantity : Math.Round((decimal)ci.Quantity / 1000, 1);
            return ShortUom(quantityDisplayed, ci.Quantity, ci.IsInGrams);
        }
    }
}