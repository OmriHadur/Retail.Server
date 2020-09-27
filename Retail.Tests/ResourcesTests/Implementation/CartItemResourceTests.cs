using Core.Server.Shared.Errors;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;
using System.Linq;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class CartItemResourceTests : ResourceTests<CartItemCreateResource, CartItemResource>
    {
        public override void TestCreateAddedToList() { }

        [TestMethod]
        public void TestCartPrice()
        {
            var cart = ResourcesHolder.GetLastOrCreate<CartResource>().Value;
            Assert.AreEqual(CreatedResource.ItemPrice.TotalPrice, cart.CartPrice.TotalPrice);
        }

        [TestMethod]
        public void TestTwoProducts()
        {
            var firstCartItem = CreatedResource;
            ResourcesHolder.Create<ProductResource>();
            CreateResource();
            var cart = ResourcesHolder.GetLastOrCreate<CartResource>().Value;
            Assert.AreEqual(2, cart.Items.Count());
            decimal cartPrice = firstCartItem.ItemPrice.TotalPrice + CreatedResource.ItemPrice.TotalPrice;
            Assert.AreEqual(cartPrice, cart.CartPrice.TotalPrice);
        }

        [TestMethod]
        public void TestSameProducts()
        {
            var result = ResourcesHolder.Create<CartItemResource>();
            AssertBadRequestReason(result, BadRequestReason.SameExists);
            var cart = ResourcesHolder.GetLastOrCreate<CartResource>().Value;
            Assert.AreEqual(1, cart.Items.Count());
        }

        [TestMethod]
        public void TestItemTotalPrice()
        {
            var productPrice = GetExistingOrNew<ProductResource>().Price;
            Assert.AreEqual(productPrice * CreatedResource.Quantity, CreatedResource.ItemPrice.TotalPrice);
        }
    }
}
