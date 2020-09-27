using Core.Server.Shared.Errors;
using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Client.Interfaces;
using Retail.Shared.Resources;
using System.Linq;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class ProductResourceTests : ResourceTests<ProductCreateResource, ProductResource>
    {
        [TestMethod]
        public void TestSameBarcode()
        {
            var procuctResource = ResourcesHolder.GetLastOrCreate<ProductResource>().Value;
            var response = ResourcesHolder.EditAndCreate<ProductCreateResource, ProductResource>(p => p.Barcode = procuctResource.Barcode);
            AssertBadRequestReason(response, BadRequestReason.SameExists);
        }

        [TestMethod]
        public void TestSearch()
        {
            var response = GetClient<IProductsControllClient>().Search(CreatedResource.Description).Result;
            Assert.AreEqual(CreatedResource, response.Value.First());
        }

        [TestMethod]
        public void TestSubCategory()
        {
            var sub = ResourcesHolder.GetLastOrCreate<CategoryResource>().Value;
            var response = GetClient<IProductsControllClient>().GetByCategory(sub.Id).Result;
            Assert.AreEqual(CreatedResource, response.Value.First());
        }
    }
}
