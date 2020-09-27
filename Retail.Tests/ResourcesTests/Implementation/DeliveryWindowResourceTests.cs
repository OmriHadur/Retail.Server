using Core.Server.Shared.Errors;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Shared.Errors;
using Retail.Shared.Resources.Order;
using System;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class DeliveryWindowResourceTests : ResourceTests<DeliveryWindowCreateResource, DeliveryWindowResource>
    {
        [TestMethod]
        public void TestDeliveryInvalidToHour()
        {
            var response = ResourcesHolder.EditAndCreate<DeliveryWindowCreateResource, DeliveryWindowResource>(d => { d.ToHour = 1; d.ToHour = 0; });
            AssertBadRequestReason(response, BadRequestReasonExtended.InvalidToHour);
        }

        [TestMethod]
        public void TestDeliveryAfterExistingStart()
        {
            var createResource = GetCreate(1, 1);
            var response = ResourcesHolder.Create<DeliveryWindowCreateResource, DeliveryWindowResource>(createResource);
            AssertBadRequestReason(response, BadRequestReason.SameExists);
        }

        [TestMethod]
        public void TestDeliveryBeforeExistingEnd()
        {
            var createResource = GetCreate(-1, -1);
            var response = ResourcesHolder.Create<DeliveryWindowCreateResource, DeliveryWindowResource>(createResource);
            AssertBadRequestReason(response, BadRequestReason.SameExists);
        }

        [TestMethod]
        public void TestDeliveryNotAvilibale()
        {
            ResourcesHolder.GetLastOrCreate<OrderResource>();

            var deliveryWindow = ResourcesHolder.GetLastOrCreate<DeliveryWindowResource>().Value;

            Assert.IsFalse(deliveryWindow.IsAvailable);
        }

        [TestMethod]
        public void TestDeliveryAvailable()
        {
            var deliveryWindow = ResourcesHolder.GetLastOrCreate<DeliveryWindowResource>().Value;

            Assert.IsTrue(deliveryWindow.IsAvailable);
        }

        private DeliveryWindowCreateResource GetCreate(int addToFrom, int addToTo)
        {
            return new DeliveryWindowCreateResource()
            {
                Date = CreatedResource.Date,
                FromHour = Math.Max(0, CreatedResource.FromHour + addToFrom),
                ToHour = Math.Min(23, CreatedResource.ToHour + addToTo)
            };
        }
    }
}