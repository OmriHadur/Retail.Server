using AutoMapper;
using Retail.Common.Entities;
using Retail.Common.Helpers;
using Retail.Common.Repositories;
using System.Threading.Tasks;
using Unity;
using Retail.Common;
using System;

namespace Retail.Application.Helper
{
    [Inject]
    public class PromotionsApplayer : IPromotionsApplayer
    {
        [Dependency]
        public IPromotionsRepository promotionsRepository;

        [Dependency]
        public IMapper Mapper { get; set; }

        //[Dependency]
        //public ILogger<PromotionsApplayer> logger { get; set; }

        public async Task ApplayOnItem(CartEntity cartEntity, CartItemEntity cartItem)
        {
            cartItem.Promotion = null;
            var promotionRelated = await GetPromotionRelated(cartItem);
            if (promotionRelated == null)
                return;
            var promotionApplies = PromotionApplies(cartItem, promotionRelated);
            if (promotionApplies == 0)
                return;

            ApplayPromotion(cartItem, promotionRelated, promotionApplies);
        }

        private void ApplayPromotion(CartItemEntity cartItemAdded, PromotionEntity promotionRelated, int promotionApplies)
        {
            if (cartItemAdded.Promotion == null)
                cartItemAdded.Promotion = Mapper.Map<CartItemPromotion>(promotionRelated);

            var discountPerApply = GetDiscountPerApply(promotionRelated, cartItemAdded);
            cartItemAdded.Promotion.Discount = Math.Round(promotionApplies * discountPerApply, 2);
        }

        private static decimal GetDiscountPerApply(PromotionEntity promotionRelated, CartItemEntity cartItem)
        {
            return ((decimal)promotionRelated.DiscountPercentage / 100) * cartItem.Price;
        }

        private int PromotionApplies(CartItemEntity cartItem, PromotionEntity promotionRelated)
        {
            var quantity = cartItem.Quantity / (cartItem.IsWeighable ? cartItem.Size : 1);
            var applies = quantity / promotionRelated.TriggeringQuantity;
            if (applies > 1 && !promotionRelated.IsReApply)
                return 1;
            return applies;
        }

        private async Task<PromotionEntity> GetPromotionRelated(CartItemEntity cartItem)
        {
            return await promotionsRepository.GetByProductId(cartItem.Id);
        }
    }
}
