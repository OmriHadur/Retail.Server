using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unity;
using System.Linq;

using Core.Server.Common;
using Core.Server.Application;
using Retail.Common.Entities;
using Core.Server.Common.Repositories;
using Retail.Common.Entities.Helpers;
using Retail.Common.Repositories;
using Retail.Standard.Shared.Resources.Order;
using System;
using Core.Server.Common.Entities;

namespace Retail.Application.Helpers
{
    [Inject]
    public class OrderEntityFactory : ApplicationBase, IOrderEntityFactory
    {
        [Dependency]
        public IUsersRepository usersRepository;
        [Dependency]
        public ICartsRepository cartsRepository;
        [Dependency]
        public IDeliveryWindowsRepository deliveryWindowsRepository;

        public async Task<ActionResult<OrderEntity>> CreateOrderEntity(OrderCreateResource createResource, string userId)
        {
            var creatingEntitiesResult = await GetCreatingEntities(createResource, userId);
            if (creatingEntitiesResult.Value == null)
                return creatingEntitiesResult.Result;
            return GetOrderEntity(creatingEntitiesResult.Value);
        }

        private static OrderEntity GetOrderEntity(OrderCreatingEntities creatingEntities)
        {
            return new OrderEntity()
            {
                Address = creatingEntities.Address,
                Cart = creatingEntities.Cart,
                DeliveryWindow = creatingEntities.DeliveryWindow,
                CustomerFullName = $"{creatingEntities.User.FirstName} {creatingEntities.User.LastName}",
                Created = DateTime.Now
            };
        }

        private async Task<ActionResult<OrderCreatingEntities>> GetCreatingEntities(OrderCreateResource createResource, string userId)
        {
            var creatingEntities = new OrderCreatingEntities();
            creatingEntities.User = await usersRepository.Get(userId);
            if (creatingEntities.User == null)
                return new UnauthorizedResult();
            //TODO
            //creatingEntities.Address = creatingEntities.User.Adresses.FirstOrDefault(ad => ad.Id == createResource.AddressId);
            if (creatingEntities.Address == null)
                return NotFound(createResource.AddressId);
            creatingEntities.Cart = await cartsRepository.Get(createResource.CartId);
            if (creatingEntities.Cart == null)
                return NotFound(createResource.CartId);
            creatingEntities.DeliveryWindow = await deliveryWindowsRepository.Get(createResource.DeliveryWindowId);
            if (creatingEntities.DeliveryWindow == null)
                return NotFound(createResource.DeliveryWindowId);
            creatingEntities.DeliveryWindow.Orders = null;
            return creatingEntities;
        }

        private class OrderCreatingEntities
        {
            public UserEntity User;
            public AddressEntity Address;
            public CartEntity Cart;
            public DeliveryWindowEntity DeliveryWindow;
        }
    }
}