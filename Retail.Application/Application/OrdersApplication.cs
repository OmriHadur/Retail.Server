using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unity;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources.Order;
using Retail.Common.Entities.Helpers;
using Retail.Common.Repositories;
using Retail.Common.Enums;

namespace Retail.Application.Application
{
    [Inject]
    public class OrdersApplication : RestApplication<OrderCreateResource, OrderResource, OrderEntity>, IOrdersApplication
    {
        [Dependency]
        public IOrderEntityFactory OrderEntityFactory;
        [Dependency]
        public IDeliveryWindowOrdersApplication DeliveryWindowOrdersApplication;

        public async Task<ActionResult<IEnumerable<OrderResource>>> GetMyOrders()
        {
            var entities = await (Repository as IOrdersRepository).GetAllByCustomer(CurrentUser.Id);
            return MapMany(entities);
        }
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetAllByStats(eOrderStatus ordered)
        {
            var entities = await (Repository as IOrdersRepository).GetAllByStats(ordered);
            return MapMany(entities);
        }

        public async override Task<ActionResult<OrderResource>> Update(string orderId, OrderCreateResource createResource)
        {
            var orderEntity = await Repository.Get(orderId);
            if (orderEntity == null)
                return NotFound(orderId);
            var orderEntityResult = await OrderEntityFactory.CreateOrderEntity(createResource,CurrentUser.Id);
            if (orderEntityResult.Value == null)
                return orderEntityResult.Result;
            orderEntityResult.Value.Id = orderId;
            await Repository.Update(orderEntityResult.Value);
            await UpdateDeliveryWindow(createResource, orderEntity);
            return await Map(orderEntityResult.Value);
        }

        public async override Task<ActionResult<OrderResource>> Create(OrderCreateResource createResource)
        {
            var orderEntityResult = await OrderEntityFactory.CreateOrderEntity(createResource, CurrentUser.Id);
            if (orderEntityResult.Value == null)
                return orderEntityResult.Result;
            var orderEntity = orderEntityResult.Value;
            await AddEntity(orderEntity);
            await AddOrderToDeliveryWindow(createResource, orderEntity);
            return await Map(orderEntity);
        }

        public async Task<ActionResult<OrderResource>> SetStatus(string orderId, eOrderStatus status)
        {
            var orderEntity = await Repository.Get(orderId);
            if (orderEntity == null)
                return NotFound(orderId);
            orderEntity.Status = status;
            await Repository.Update(orderEntity);
            return await Map(orderEntity);
        }
        private async Task AddOrderToDeliveryWindow(OrderCreateResource createResource, OrderEntity orderEntity)
        {
            var resource = new DeliveryWindowOrderCreateResource() { OrderId = orderEntity.Id };
            await DeliveryWindowOrdersApplication.Create(createResource.DeliveryWindowId, resource);
        }

        private async Task RemoveOrderFromDeliveryWindow(OrderEntity orderEntity)
        {
            await DeliveryWindowOrdersApplication.Delete(orderEntity.DeliveryWindow.Id, orderEntity.Id);
        }

        private async Task UpdateDeliveryWindow(OrderCreateResource createResource, OrderEntity orderEntity)
        {
            await RemoveOrderFromDeliveryWindow(orderEntity);
            await AddOrderToDeliveryWindow(createResource, orderEntity);
        }
    }
}
