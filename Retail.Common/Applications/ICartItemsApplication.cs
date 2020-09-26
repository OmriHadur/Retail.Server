using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface ICartItemsApplication : IInnerRestApplication<CartItemCreateResource, CartItemResource>
    {
        Task<ActionResult<CartItemResource>> Scan(string parentId, CartItemCreateScanResource resource);
    }
}
