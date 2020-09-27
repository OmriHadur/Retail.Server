using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Client.Interfaces;
using Retail.Shared.Resources.Order;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class OrderResourceTests : ResourceTests<OrderCreateResource, OrderResource>
    {
        [TestMethod]
        public void TestMyOrders()
        {
            var response = GetClient<IOrdersControllClient>().GetMyOrders().Result;
            Assert.AreEqual(1, response.Value.Count());
            Assert.AreEqual(CreatedResource, response.Value.First());
        }

        [TestMethod]
        public void TestOrderInPendingOrdered()
        {
            var response = GetClient<IOrdersControllClient>().GetPendingOrdered().Result;
            Assert.IsTrue(response.Value.Contains(CreatedResource));
        }

        [TestMethod]
        public void TestOrderShipped()
        {
            var response = GetClient<IOrdersControllClient>().SetOrderShipped(CreatedResource.Id).Result;
            Assert.AreEqual("Shipped", response.Value.Status);
        }

        [TestMethod]
        public async Task TestOrderNotInPendingOrderedAfterShipped()
        {
            await GetClient<IOrdersControllClient>().SetOrderShipped(CreatedResource.Id);
            var response = GetClient<IOrdersControllClient>().GetPendingOrdered().Result;
            Assert.IsFalse(response.Value.Contains(CreatedResource));
        }
    }
}
