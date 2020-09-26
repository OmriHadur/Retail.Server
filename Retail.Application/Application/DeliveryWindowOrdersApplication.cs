using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources.Order;
using Retail.Common;
using Unity;
using System.Collections.Generic;

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