using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;
using System;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class PromotionResourceTests : ResourceTests<PromotionCreateResource, PromotionResource>
    {
        [TestMethod]
        public void TestOnePromotionNotApplies()
        {
            var cartItem = AddCartItem(-1);

            var cart = GetExistingOrNew<CartResource>();
            Assert.AreEqual(cartItem.ItemPrice.TotalPrice, cart.CartPrice.TotalPrice);
            Assert.IsFalse(cartItem.ItemPrice.HasDiscount);
        }

        [TestMethod]
        public void TestOnePromotionApplies()
        {
            var cartItem = AddCartItem();
            var expectedPromotionDiscount = ExpectedPromotionDiscount(1);
            Assert.AreEqual(expectedPromotionDiscount, cartItem.ItemPrice.BeforeDiscount - cartItem.ItemPrice.TotalPrice);
        }

        [TestMethod]
        public void TestTwoPromotionApplies()
        {
            ResourcesHolder.Delete<PromotionResource>(CreatedResource.Id);
            Action<PromotionCreateResource> edit = p => { p.TriggeringQuantity = 2; p.IsReApply = true; };
            CreatedResource = ResourcesHolder.EditAndCreate<PromotionCreateResource, PromotionResource>(edit).Value;

            AddCartItem(2);

            var cart = GetExistingOrNew<CartResource>();
            var expectedPromotionDiscount = ExpectedPromotionDiscount(2);
            Assert.AreEqual(expectedPromotionDiscount, cart.CartPrice.BeforeDiscount - cart.CartPrice.TotalPrice);
        }

        [TestMethod]
        public void Test_Promotion_On_Weighable_Product()
        {
            var cartItemEdit = GetCartItemEdit(0);

            var cartItem = ResourcesHolder.EditAndCreate<CartItemCreateResource, CartItemResource>(cartItemEdit).Value;

            Assert.IsTrue(cartItem.ItemPrice.HasDiscount);
        }

        [TestMethod]
        public void Test_No_Promotion_On_Weighable_Product()
        {
            var cartItemEdit = GetCartItemEdit(-1);

            var cartItem = ResourcesHolder.EditAndCreate<CartItemCreateResource, CartItemResource>(cartItemEdit).Value;

            Assert.IsFalse(cartItem.ItemPrice.HasDiscount);
        }

        private Action<CartItemCreateResource> GetCartItemEdit(int extraQuantity=0)
        {
            var product = ResourcesHolder.EditAndCreate<ProductCreateResource, ProductResource>(p => p.IsWeighable = true).Value;
            ResourcesHolder.EditAndCreate<PromotionCreateResource, PromotionResource>(p => p.TriggeringQuantity = 1);
            return c => { c.ProductId = product.Id; c.Quantity = product.Size + extraQuantity; };
        }

        private decimal ExpectedPromotionDiscount(int applies)
        {
            var expectedDiscount = CreatedResource.Product.Price * ((decimal)CreatedResource.DiscountPercentage / 100);
            return Math.Round(expectedDiscount * applies, 2);
        }

        private CartItemResource AddCartItem(int extraItem = 0)
        {
            var createResource = new CartItemCreateResource()
            {
                ProductId = CreatedResource.Product.Id,
                Quantity = CreatedResource.TriggeringQuantity + extraItem
            };

            return ResourcesHolder.Create<CartItemCreateResource, CartItemResource>(createResource).Value;
        }
    }
}