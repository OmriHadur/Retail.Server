using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Client.Interfaces;
using Retail.Shared.Errors;
using Retail.Shared.Resources.Order;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class OrderItemResourceTests : ResourceTests<OrderItemCreateResource, OrderItemResource>
    {
        [TestMethod]
        public void TestAddItemsOrderStatusShipped()
        {
            SetOrderShipped();

            var response = ResourcesHolder.Create<OrderItemResource>();

            AssertBadRequestReason(response, BadRequestReasonExtended.OrderNotPending);
        }

        [TestMethod]
        public void TestUpdateItemsOrderStatusShipped()
        {
            SetOrderShipped();
            var resourceToUpdate = ResourceCreator.GetRandomCreateResource();

            var response = ResourceCreator.Update(CreatedResource.Id, resourceToUpdate);

            AssertBadRequestReason(response, BadRequestReasonExtended.OrderNotPending);
        }

        private void SetOrderShipped()
        {
            var orderClient = GetClient<IOrdersControllClient>();
            var orderId = ResourcesHolder.GetResourceId<OrderResource>();
            orderClient.SetOrderShipped(orderId).Wait();
        }
    }
}