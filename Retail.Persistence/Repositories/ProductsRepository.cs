using System.Threading.Tasks;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using Core.Server.Persistence.Repositories;
using Core.Server.Common;

namespace Retail.Persistence.Repositories
{
    [Inject]
    public class ProductsRepository : MongoRepository<ProductEntity>, IProductsRepository
    {

        public async Task<ProductEntity> GetByBarcode(string barcode)
        {
            return await FindFirst(pe => pe.Barcode == barcode);
        }

        public async Task<bool> HasBarcodeOrName(string barcode)
        {
            var productEntity = await GetByBarcode(barcode);
            return productEntity != null;
        }

        public async Task<IEnumerable<ProductEntity>> GetByDescription(string descriptionOrBarcode)
        {
            return (await Entities.FindAsync(p =>
                p.Description.ToLower()
                .Contains(descriptionOrBarcode.ToLower()))).ToList();
        }

        public async Task<IEnumerable<ProductEntity>> GetByCategory(string categoryId)
        {
            return (await Entities.FindAsync(p =>
                p.CategoryId == categoryId)).ToList();
        }
    }
}