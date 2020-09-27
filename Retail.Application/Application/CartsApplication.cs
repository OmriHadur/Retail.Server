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
using Retail.Shared.Resources.Cart;
using System.Linq;
using System;

namespace Retail.Application.Application
{
    [Inject]
    public class CartsApplication : RestApplication<CartCreateResource, CartResource, CartEntity>, ICartsApplication
    {
        public async Task<ActionResult<CartResource>> GetMyCart()
        {
            return await Map(await GetByUserId());
        }

        public async override Task<ActionResult<CartResource>> Create(CartCreateResource createResource)
        {
            var prevCart = await GetByUserId();
            if (prevCart != null)
                return BadRequest(BadRequestReason.SameExists);
            return await base.Create(createResource);
        }

        public async Task<ActionResult<CartResource>> GetOrCreate(CartCreateResource createResource)
        {
            var cart = await GetByUserId();
            if (cart == null)
                return await base.Create(createResource);
            else
                return await Map(cart);
        }
        protected override CartEntity GetNewTEntity(CartCreateResource resource)
        {
            return new CartEntity
            {
                CustomerId = CurrentUser?.Id,
                Items = new List<CartItemEntity>()
            };
        }

        private async Task<CartEntity> GetByUserId()
        {
            if (CurrentUser == null) return null;
            return await (Repository as ICartsRepository).GetByUserId(CurrentUser.Id);
        }

        public async Task<ActionResult<CartResource>> Assign(string cartId)
        {
            var cart = await Repository.Get(cartId);
            if (cart.CustomerId != null)
                return BadRequest(BadRequestReason.SameExists);
            if (await GetByUserId() != null)
                return BadRequest(BadRequestReason.SameExists);
            cart.CustomerId = CurrentUser.Id;
            await Repository.Update(cart);
            return await Map(cart);
        }

        public async Task<ActionResult<CartResource>> AddOrder(string cartId, string orderId)
        {
            var cart = await Repository.Get(cartId);
            if (cart == null)
                return NotFound(cartId);
            var order = await GetOrder(orderId);
            if (order == null)
                return NotFound(orderId);

            await AddCartItems(cart, order);
            await Repository.Update(cart);
            return await Map(cart);
        }

        private async Task AddCartItems(CartEntity cart, OrderEntity order)
        {
            var promotionsApplayer = UnityContainer.Resolve<IPromotionsApplayer>();
            foreach (var cartItem in order.Cart.Items)
                if (cartItem.Quantity > 0)
                    await AddCartItem(cart, promotionsApplayer, cartItem);
        }

        private static async Task AddCartItem(CartEntity cart, IPromotionsApplayer promotionsApplayer, CartItemEntity cartItem)
        {
            var existingCartItem = cart.Items.FirstOrDefault(ci => ci.Id == cartItem.Id);
            if (cartItem.IsWeighable)
                cartItem.Quantity = (cartItem.Quantity / cartItem.QuantityInterval) * cartItem.QuantityInterval;
            if (existingCartItem == null)
                cart.Items.Add(cartItem);
            else
                existingCartItem.Quantity = Math.Max(existingCartItem.Quantity, cartItem.Quantity);

            await promotionsApplayer.ApplayOnItem(cart, cartItem);
        }

        private async Task<OrderEntity> GetOrder(string orderId)
        {
            return await UnityContainer.Resolve<IOrdersRepository>().Get(orderId);
        }
    }
}
