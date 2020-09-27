using Core.Server.Client.Interfaces;
using Core.Server.Shared.Resources;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Client.Interfaces;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;
using Retail.Shared.Resources.Order;
using Retail.Tests.RestRourcesTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Retail.Tests.DBFilling
{
    [TestClass]
    public class FillDatabase : TestsBase
    {
        private readonly int SCALE = 5;
        private readonly Random random = new Random();

        [TestMethod]
        public void FillDatabaseWithProducts()
        {
            for (int c = 0; c < 5; c++)
            {
                ResourcesHolder.Create<DepartmentResource>();
                for (int f = 0; f < 3; f++)
                {
                    var category = GetRandomCreateResource<CategoryCreateResource, CategoryResource>();
                    var family = category.FamilyName;
                    for (int s = 0; s < 3; s++)
                    {
                        ResourcesHolder.EditAndCreate<CategoryCreateResource, CategoryResource>(sc => sc.FamilyName = family);
                        for (int p = 0; p < SCALE; p++)
                            ResourcesHolder.EditAndCreate<ProductCreateResource, ProductResource>(EditProductToWeighable());
                    }
                    ResourcesHolder.Create<PromotionResource>();
                }
            }
        }

        private Action<ProductCreateResource> EditProductToWeighable()
        {
            return p =>
            {
                p.IsWeighable = random.Next(3) == 0;
                if (p.IsWeighable)
                {
                    p.IsInGrams = true;
                    p.Size = 1000;
                    p.QuantityInterval = 100 + random.Next(9) * 100;
                }
            };
        }

        [TestMethod]
        public void FillDatabaseWithDeliveryWindows()
        {
            for (int i = 0; i < SCALE; i++)
                ResourcesHolder.Create<DeliveryWindowResource>();
            ResourcesHolder.Create<OrderResource>();
        }

        [TestMethod]
        public void FillDatabaseWithOrders()
        {
            var allProducts = GetAll<ProductCreateResource, ProductResource>();
            var allPromotions = GetAll<PromotionCreateResource, PromotionResource>();

            for (int i = 0; i < SCALE; i++)
            {
                TokenHandler.LoginWithNewUser();
                ResourcesHolder.Create<CartResource>();

                AddItemsToCart(allProducts, allPromotions);

                ResourcesHolder.Create<AddressResource>();
                ResourcesHolder.Create<OrderResource>();
                ResourcesHolder.DeleteAll<CartResource>();
            }
        }

        private List<TResource> GetAll<TCreateResource, TResource>()
            where TCreateResource : CreateResource
            where TResource : Resource
        {
            var response = GetClient<IRestClient<TCreateResource, TResource>>().Get().Result;
            return response.Value.ToList();
        }

        private void AddItemsToCart(List<ProductResource> allProducts, List<PromotionResource> allPromotions)
        {
            CartItemCreateResource cartItemCreateResource;
            for (int j = 0; j < SCALE; j++)
            {
                cartItemCreateResource = new CartItemCreateResource() { ProductId = GetRadomResources(allProducts).Id, Quantity = random.Next(10) };
                CreateCartItem(cartItemCreateResource);
            }
            cartItemCreateResource = GetPromotionTriggeringItem(allPromotions);
            CreateCartItem(cartItemCreateResource);
        }

        private void CreateCartItem(CartItemCreateResource cartItemResource)
        {
            ResourcesHolder.Create<CartItemCreateResource, CartItemResource>(cartItemResource);
        }

        private T GetRadomResources<T>(List<T> resources)
        {
            return resources[random.Next(resources.Count)];
        }

        private CartItemCreateResource GetPromotionTriggeringItem(List<PromotionResource> allPromotions)
        {
            var promotion = GetRadomResources(allPromotions);
            return new CartItemCreateResource()
            {
                ProductId = promotion.Product.Id,
                Quantity = promotion.TriggeringQuantity
            };
        }
    }
}