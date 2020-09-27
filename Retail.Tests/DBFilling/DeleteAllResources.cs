using Core.Server.Client.Interfaces;
using Core.Server.Shared.Resources;
using Core.Server.Shared.Resources.Users;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Cart;
using Retail.Shared.Resources.Order;

namespace Retail.Tests.DBFilling
{
    [TestClass]
    public class DeleteAllResources : TestsBase
    {
        [TestMethod]
        public void TestDeleteAllResources()
        {
            DeleteAllResourcesOfType<CartCreateResource, CartResource>();
            DeleteAllResourcesOfType<PromotionCreateResource, PromotionResource>();
            DeleteAllResourcesOfType<ProductCreateResource, ProductResource>();
            DeleteAllResourcesOfType<DepartmentCreateResource, DepartmentResource>();
            DeleteAllResourcesOfType<LoginCreateResource, LoginResource>();
            DeleteAllResourcesOfType<UserCreateResource, UserResource>();
            DeleteAllResourcesOfType<OrderCreateResource, OrderResource>();
            DeleteAllResourcesOfType<DeliveryWindowCreateResource, DeliveryWindowResource>();
        }
        private void DeleteAllResourcesOfType<TCreateResource, TResource>()
            where TCreateResource : CreateResource
            where TResource : Resource
        {
            ResourcesHolder.DeleteAll<TResource>();
            var resourceClient = GetClient<IRestClient<TCreateResource, TResource>>();
            var resources = resourceClient.Get().Result;
            foreach (var resource in resources.Value)
                resourceClient.Delete(resource.Id).Wait();
        }
    }
}