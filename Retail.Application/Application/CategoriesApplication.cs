using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unity;
using System.Linq;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using MongoDB.Bson;

namespace Retail.Application.Application
{
    [Inject]
    public class CategoriesApplication : InnerRestApplication<CategoryCreateResource, CategoryResource, DepartmentEntity, CategoryEntity>, ICategoriesApplication
    {
        protected override ICollection<CategoryEntity> GetEntities(DepartmentEntity parent)
        {
            return parent.CategoriesByFamily.SelectMany(c => c.Value).ToList();
        }

        protected async override Task<ActionResult<CategoryEntity>> AddToParent(DepartmentEntity parent, CategoryCreateResource createResource)
        {
            var entity = new CategoryEntity() { Id = ObjectId.GenerateNewId().ToString(), Name = createResource.Name };
            AddEntityToParent(parent, entity,createResource);
            return entity;
        }

        private void AddEntityToParent(DepartmentEntity parent, CategoryEntity entity, CategoryCreateResource createResource)
        {
            if (!parent.CategoriesByFamily.ContainsKey(createResource.FamilyName))
                parent.CategoriesByFamily.Add(createResource.FamilyName, new List<CategoryEntity>());
            parent.CategoriesByFamily[createResource.FamilyName].Add(entity);
        }

        protected override Task UpdateItemOnParent(DepartmentEntity parent, CategoryEntity entity, CategoryCreateResource resource)
        {
            RemoveFromParent(parent, entity);
            Mapper.Map(resource, entity);
            AddEntityToParent(parent, entity, resource);
            return Task.CompletedTask;
        }

        protected override void RemoveFromParent(DepartmentEntity parent, CategoryEntity entity)
        {
            var familyKeyPair = parent.CategoriesByFamily.FirstOrDefault(c => c.Value.Contains(entity));
            parent.CategoriesByFamily[familyKeyPair.Key].Remove(entity);
            if (familyKeyPair.Value.Count == 0)
                parent.CategoriesByFamily.Remove(familyKeyPair.Key);
        }
    }
}
