using Core.Server.Tests.ResourceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Shared.Resources;
using System.Linq;

namespace Retail.Tests.RestRourcesTests
{
    [TestClass]
    public class CategoryResourceTests : ResourceTests<CategoryCreateResource, CategoryResource>
    {
        [TestMethod]
        public virtual void TestFamilyUpdate()
        {
            var resourceToUpdate = ResourceCreator.GetRandomCreateResource();
            ResourceCreator.Update(CreatedResource.Id, resourceToUpdate);
            var category = ResourcesHolder.GetLastOrCreate<DepartmentResource>().Value;
            Assert.AreEqual(resourceToUpdate.FamilyName, category.Families.First().Name);
            Assert.AreEqual(resourceToUpdate.Name, category.Families.First().Categories.First().Name);
        }
    }
}
