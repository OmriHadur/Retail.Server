using Microsoft.AspNetCore.Mvc;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface IProductsRepository : IRepository<ProductEntity>
    {
        Task<bool> HasBarcodeOrName(string barcode);

        Task<ProductEntity> GetByBarcode(string barcode);
        Task<IEnumerable<ProductEntity>> GetByDescription(string descriptionOrBarcode);
        Task<IEnumerable<ProductEntity>> GetByCategory(string CategoryId);
    }
}
