﻿using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unity;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources.Order;
using Retail.Common.Repositories;
using Retail.Common.Helpers;
using Core.Server.Shared.Errors;
using Retail.Shared.Errors;

namespace Retail.Application.Application
{
    [Inject]
    public class OrderItemsApplication : InnerRestApplication<OrderItemCreateResource, OrderItemResource, OrderEntity, CartItemEntity>, IOrderItemsApplication
    {
        [Dependency]
        public IProductsRepository ProductsRepository { get; set; }

        [Dependency]
        public IPromotionsApplayer promotionsApplayer;

        protected override ICollection<CartItemEntity> GetEntities(OrderEntity order)
        {
            return order.Cart.Items;
        }

        protected async override Task<ActionResult<CartItemEntity>> AddToParent(OrderEntity order, OrderItemCreateResource resource)
        {
            if (order.Status != Common.Enums.eOrderStatus.Pending)
                return BadRequest(BadRequestReasonExtended.OrderNotPending);
            var productEntity = await ProductsRepository.Get(resource.ProductId);
            if (productEntity == null)
                return NotFound(resource.ProductId);

            if (GetEntity(order, productEntity.Id) != null)
                return BadRequest(BadRequestReason.SameExists);
            var cartItem = Mapper.Map<CartItemEntity>(productEntity);
            Mapper.Map(resource, cartItem);
            order.Cart.Items.Add(cartItem);
            await promotionsApplayer.ApplayOnItem(order.Cart, cartItem);
            return cartItem;
        }

        public override async Task<ActionResult<OrderItemResource>> Update(string parentId, string id, OrderItemCreateResource resource)
        {
            var order = await Repository.Get(parentId);
            if (order == null) return NotFound(parentId);

            if (order.Status != Common.Enums.eOrderStatus.Pending)
                return BadRequest(BadRequestReasonExtended.OrderNotPending);
            return await UpdateCartItemEntity(id, resource, order);
        }

        private async Task<ActionResult<OrderItemResource>> UpdateCartItemEntity(string id, OrderItemCreateResource resource, OrderEntity order)
        {
            var cartItemEntity = GetEntity(order, id);
            if (cartItemEntity == null)
                return NotFound(id);
            cartItemEntity.Quantity = resource.Quantity;
            await promotionsApplayer.ApplayOnItem(order.Cart, cartItemEntity);
            return await UpdateAndMap(order, cartItemEntity);
        }
    }
}
