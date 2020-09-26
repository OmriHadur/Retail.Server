using System.Collections.Generic;
using Unity;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources.Order;

namespace Retail.Application.Application
{
    [Inject]
    public class DeliveryWindowOrdersApplication :
        InnerRestApplication<DeliveryWindowOrderCreateResource, DeliveryWindowOrderResource, DeliveryWindowEntity, DeliveryWindowOrderEntity>,
        IDeliveryWindowOrdersApplication
    {
        protected override ICollection<DeliveryWindowOrderEntity> GetEntities(DeliveryWindowEntity parent)
        {
            return parent.Orders;
        }
    }
}