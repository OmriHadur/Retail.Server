using Core.Server.Tests.ResourceCreators;
using Retail.Shared.Resources.Order;
using System;

namespace Retail.Tests.RestResourcesCreators
{
    public class DeliveryWindowResourceCreator :
        RestResourceCreator<DeliveryWindowCreateResource, DeliveryWindowResource>
    {

        public override void SetCreateResource(DeliveryWindowCreateResource createResource)
        {
            base.SetCreateResource(createResource);
            createResource.FromHour = Math.Min(19, createResource.FromHour);
            createResource.ToHour = createResource.FromHour + 4;
        }
    }
}
