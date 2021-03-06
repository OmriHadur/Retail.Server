﻿using Retail.Shared.Resources.Cart;
using Retail.Shared.Resources.Order;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface IOrderItemsApplication : IInnerRestApplication<OrderItemCreateResource, OrderItemResource>
    {
    }
}
