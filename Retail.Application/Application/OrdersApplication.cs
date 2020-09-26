using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Common;
using Unity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retail.Common.Repositories;
using System.Collections.Generic;
using Retail.Common.Enums;
using Retail.Standard.Shared.Resources.Order;
using Retail.Common.Entities.Helpers;

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
            return Map(orderEntityResult.Value);
        }

        public async override Task<ActionResult<OrderResource>> Create(OrderCreateResource createResource)
        {
            var orderEntityResult = await OrderEntityFactory.CreateOrderEntity(createResource, CurrentUser.Id);
            if (orderEntityResult.Value == null)
                return orderEntityResult.Result;
            var orderEntity = await AddEntityToDb(orderEntityResult.Value);
            await AddOrderToDeliveryWindow(createResource, orderEntity);
            return Map(orderEntity);
        }

        public async Task<ActionResult<OrderResource>> SetStatus(string orderId, eOrderStatus status)
        {
            var orderEntity = await Repository.Get(orderId);
            if (orderEntity == null)
                return NotFound(orderId);
            orderEntity.Status = status;
            await Repository.Update(orderEntity);
            return Map(orderEntity);
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
