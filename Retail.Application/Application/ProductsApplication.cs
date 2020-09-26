using Retail.Common.Applications;
using Retail.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Retail.Common.Repositories;
using Unity;
using Retail.Common;
using Retail.Standard.Shared.Resources;
using Retail.Standard.Shared.Errors;
using System.Collections.Generic;
using System.Linq;

namespace Retail.Application.Application
{
    [Inject]
    public class ProductsApplication : RestApplication<ProductCreateResource, ProductResource, ProductEntity>, IProductsApplication
    {
        public async override Task<ActionResult<ProductResource>> Create(ProductCreateResource resource)
        {
            var hasBarcodeOrName = await (Repository as IProductsRepository).HasBarcodeOrName(resource.Barcode);
            if (hasBarcodeOrName)
                return BadRequest(BadRequestReason.SameExists);
            return await base.Create(resource);
        }

        protected override async Task<ActionResult> UpdateEntity(ProductCreateResource createResource, ProductEntity entity)
        {
            var DepartmentEntity = await GetEntity<DepartmentEntity>(createResource.DepartmentId);
            if (DepartmentEntity == null)
                return NotFound(createResource.DepartmentId);
            var hasCategoryid = DepartmentEntity.CategoriesByFamily.Values.Any(c => c.Any(cc => cc.Id == createResource.CategoryId));
            if (!hasCategoryid)
                return NotFound(createResource.CategoryId);

            entity.CategoryId = createResource.CategoryId;
            entity.DepartmentName = DepartmentEntity.Name;
            return Ok();
        }

        public async Task<ActionResult<IEnumerable<ProductResource>>> GetByDescription(string descriptionOrBarcode)
        {
            var result = await (Repository as IProductsRepository).GetByDescription(descriptionOrBarcode);
            return MapMany(result);
        }

        public async Task<ActionResult<IEnumerable<ProductResource>>> GetByCategory(string categoryId)
        {
            var result = await (Repository as IProductsRepository).GetByCategory(categoryId);
            return MapMany(result);
        }
    }
}
