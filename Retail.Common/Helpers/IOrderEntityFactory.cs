using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources.Order;
using System.Threading.Tasks;

namespace Retail.Common.Entities.Helpers
{
    public interface IOrderEntityFactory
    {
        Task<ActionResult<OrderEntity>> CreateOrderEntity(OrderCreateResource createResource, string userId);
    }
}