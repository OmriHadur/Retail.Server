using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unity;

using Core.Server.Common;
using Core.Server.Application;
using Core.Server.Shared.Errors;

using Retail.Common.Repositories;
using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Common.Helpers;
using Retail.Standard.Shared.Resources.Cart;

namespace Retail.Application.Application
{
    [Inject]
    public class CartItemsApplication : InnerRestApplication<CartItemCreateResource, CartItemResource, CartEntity, CartItemEntity>, ICartItemsApplication
    {
        [Dependency]
        public IProductsRepository ProductsRepository { get; set; }

        [Dependency]
        public IPromotionsApplayer promotionsApplayer;

        public async Task<ActionResult<CartItemResource>> Scan(string parentId, CartItemCreateScanResource resource)
        {
            var cart = await Repository.Get(parentId);
            if (cart == null)
                return NotFound(parentId);
            var productEntity = await ProductsRepository.GetByBarcode(resource.Barcode);
            if (productEntity == null)
                return NotFound(resource.Barcode);
            await AddOrUpdateCartItem(cart, productEntity, 1);
            return Mapper.Map<CartItemResource>(cart);
        }

        protected override ICollection<CartItemEntity> GetEntities(CartEntity cart)
        {
            return cart.Items;
        }

        protected async override Task<ActionResult<CartItemEntity>> AddToParent(CartEntity cart, CartItemCreateResource resource)
        {
            var productEntity = await ProductsRepository.Get(resource.ProductId);
            if (productEntity == null)
                return NotFound(resource.ProductId);

            if (GetEntity(cart, productEntity.Id) != null)
                return BadRequest(BadRequestReason.SameExists);
            var cartItem = Mapper.Map<CartItemEntity>(productEntity);
            Mapper.Map(resource, cartItem);
            cart.Items.Add(cartItem);
            await promotionsApplayer.ApplayOnItem(cart, cartItem);
            return cartItem;
        }

        protected async override Task UpdateItemOnParent(CartEntity cart, CartItemEntity cartItem, CartItemCreateResource resource)
        {
            cartItem.Quantity = resource.Quantity;
            await promotionsApplayer.ApplayOnItem(cart, cartItem);
        }

        private async Task<CartItemEntity> AddOrUpdateCartItem(CartEntity cart, ProductEntity productEntity, int quantity)
        {
            var cartItem = GetEntity(cart, productEntity.Id);
            if (cartItem == null)
            {
                cartItem = Mapper.Map<CartItemEntity>(productEntity);
                cartItem.Quantity = quantity;
                cart.Items.Add(cartItem);
            }
            else
                cartItem.Quantity += quantity;
            await promotionsApplayer.ApplayOnItem(cart, cartItem);
            return cartItem;
        }
    }
}
