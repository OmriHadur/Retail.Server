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
using Retail.Common.Repositories;
using Core.Server.Shared.Errors;

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

        protected override async Task<ActionResult> Validate(ProductCreateResource createResource)
        {
            var departmentEntity = await GetEntity<DepartmentEntity>(createResource.DepartmentId);
            if (departmentEntity == null)
                return NotFound(createResource.DepartmentId);
            var hasCategoryid = departmentEntity.HasCategory(createResource.CategoryId);
            if (!hasCategoryid)
                return NotFound(createResource.CategoryId);
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
