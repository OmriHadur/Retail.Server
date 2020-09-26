using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unity;
using System.Linq;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources.Order;
using Core.Server.Shared.Errors;
using System;
using Retail.Standard.Shared.Errors;

namespace Retail.Application.Application
{
    [Inject]
    public class DeliveryWindowsApplication
        : RestApplication<DeliveryWindowCreateResource, DeliveryWindowResource, DeliveryWindowEntity>,
        IDeliveryWindowsApplication
    {
        public async Task<ActionResult<Dictionary<string, DeliveryWindowResource>>> GetSorted()
        {
            var deliveryWindows = await Repository.Get();
            var deliveryWindowsGroupBy = deliveryWindows.GroupBy(dw => dw.Date).OrderBy(dw => dw.Key);
            var deliveryWindowsOrdered = deliveryWindowsGroupBy.ToDictionary(dw => dw.Key.ToShortDateString(), dw => GetSortedAndMappedWindows(dw));
            return Ok(deliveryWindowsOrdered);
        }

        public async override Task<ActionResult<DeliveryWindowResource>> Create(DeliveryWindowCreateResource createResource)
        {
            if (createResource.FromHour >= createResource.ToHour)
                return BadRequest(BadRequestReasonExtended.InvalidToHour);
            var deliveryWindows = await Repository.Get();
            foreach (var deliveryWindow in deliveryWindows)
                if (AreCorelated(createResource, deliveryWindow))
                    return BadRequest(BadRequestReason.SameExists);

            return await base.Create(createResource);
        }

        private List<DeliveryWindowResource> GetSortedAndMappedWindows(IGrouping<DateTime, DeliveryWindowEntity> dw)
        {
            return dw.OrderBy(dw => dw.FromHour).Select(r => Mapper.Map<DeliveryWindowResource>(r)).ToList();

        }
        private static bool AreCorelated(DeliveryWindowCreateResource createResource, DeliveryWindowEntity entity)
        {
            if (entity.Date.CompareTo(createResource.Date) != 0)
                return false;
            return (entity.FromHour <= createResource.FromHour && createResource.FromHour < entity.ToHour) ||
                (entity.FromHour < createResource.ToHour && createResource.ToHour <= entity.ToHour);
        }
    }
}
