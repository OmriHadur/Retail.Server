using Core.Server.Client.Results;
using Core.Server.Shared.Errors;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Client.Interfaces;
using Retail.Shared.Resources.Cart;
using Retail.Shared.Resources.Order;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class CartResourceTests : ResourceTests<CartCreateResource, CartResource>
    {
        public override void TestCreateAddedToList() { }

        [TestMethod]
        public void TestMyCart()
        {
            var cart = GetMyCartResult().Value;

            Assert.AreEqual(CreatedResource, cart);
        }

        [TestMethod]
        public void TestMyCartEmpty()
        {
            ResourcesHolder.DeleteAll<CartResource>();

            var myCartResult = GetMyCartResult();

            AssertNotErrors(myCartResult);
            Assert.IsNull(myCartResult.Value);
        }

        [TestMethod]
        public void TestMyCartEmptyForDiffrentUser()
        {
            TokenHandler.LoginWithNewUser();

            var myCartResult = GetMyCartResult();

            AssertNotErrors(myCartResult);
            Assert.IsNull(myCartResult.Value);
        }

        [TestMethod]
        public void TestMyCartUnauthorized()
        {
            TokenHandler.Logout();

            var myCartResult = GetMyCartResult();

            AssertUnauthorized(myCartResult);
        }

        [TestMethod]
        public async Task TestAssign()
        {
            await AssignCart();

            TestMyCart();
        }

        [TestMethod]
        public async Task TestReAssign()
        {
            await AssignCart();

            var result = await GetClient<ICartsControllClient>().Assign(CreatedResource.Id);

            AssertBadRequestReason(result, BadRequestReason.SameExists);
        }

        [TestMethod]
        public async Task TestAddOrder()
        {
            ResourcesHolder.Create<CartItemResource>();
            var order = ResourcesHolder.Create<OrderResource>().Value;
            ResourcesHolder.DeleteAll<CartResource>();
            var cart = ResourcesHolder.GetLastOrCreate<CartResource>().Value;

            var result = await GetClient<ICartsControllClient>().AddOrder(cart.Id, order.Id);

            cart = result.Value;
            Assert.AreNotEqual(order.Cart.Id, cart.Id);
            Assert.AreEqual(order.Cart.Items.First(), cart.Items.First());
        }

        [TestMethod]
        public void TestReCreate()
        {
            var response = ResourceCreator.Create(new CartCreateResource());

            AssertBadRequestReason(response, BadRequestReason.SameExists);
        }

        [TestMethod]
        public void TestGetOrCreateCreatesCart()
        {
            ResourcesHolder.DeleteAll<CartResource>();
            var cartsClient = GetClient<ICartsControllClient>();

            var cartResource = cartsClient.GetOrCreate(new CartCreateResource()).Result.Value;

            Assert.AreNotEqual(cartResource, CreatedResource);
            cartsClient.Delete(cartResource.Id);
        }

        [TestMethod]
        public void TestGetOrCreateReturnLastCart()
        {
            var cartsClient = GetClient<ICartsControllClient>();

            var cartResource = cartsClient.GetOrCreate(new CartCreateResource()).Result.Value;

            Assert.AreEqual(cartResource, CreatedResource);
            cartsClient.Delete(cartResource.Id);
        }


        private ActionResult<CartResource> GetMyCartResult()
        {
            return GetClient<ICartsControllClient>().GetMyCart().Result;
        }

        private async Task AssignCart()
        {
            TokenHandler.Logout();
            CreatedResource = ResourcesHolder.Create<CartResource>().Value;
            TokenHandler.LoginWithNewUser();
            await GetClient<ICartsControllClient>().Assign(CreatedResource.Id);
        }
    }

}
