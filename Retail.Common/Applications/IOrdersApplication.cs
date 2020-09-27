using Microsoft.AspNetCore.Mvc;
using Retail.Common.Enums;
using Retail.Shared.Resources.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface IOrdersApplication : IRestApplication<OrderCreateResource, OrderResource>
    {
        Task<ActionResult<IEnumerable<OrderResource>>> GetMyOrders();
        Task<ActionResult<IEnumerable<OrderResource>>> GetAllByStats(eOrderStatus ordered);
        Task<ActionResult<OrderResource>> SetStatus(string orderId, eOrderStatus shipped);
    }
}
