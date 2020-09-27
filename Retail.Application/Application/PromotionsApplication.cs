using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unity;

using Core.Server.Common;
using Core.Server.Application;

using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using Retail.Common.Repositories;

namespace Retail.Application.Application
{
    [Inject]
    public class PromotionsApplication : RestApplication<PromotionCreateResource, PromotionResource, PromotionEntity>, IPromotionsApplication
    {
        [Dependency]
        public IProductsRepository ProductsRepository;
        public async override Task<ActionResult<PromotionResource>> Create(PromotionCreateResource resource)
        {
            var product = await GetEntity<ProductEntity>(resource.ProductId);
            if (product == null)
                return NotFound(resource.ProductId);
            var createdResult = await base.Create(resource);
            if (createdResult.Value != null)
                createdResult.Value.Product = Mapper.Map<ProductResource>(product);
            return createdResult;
        }

        public async override Task<ActionResult<PromotionResource>> Get(string id)
        {
            var promotionResource =await base.Get(id);
            if (promotionResource.Value != null)
            {
                var prodcuEntity = await ProductsRepository.Get(promotionResource.Value.Product.Id);
                promotionResource.Value.Product = Mapper.Map<ProductResource>(prodcuEntity);
            }
            return promotionResource;
        }
    }
}
