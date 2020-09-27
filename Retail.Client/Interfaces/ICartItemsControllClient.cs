using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Client.Interfaces
{
    public interface ICartItemsControllClient : IInnerRestClient<CartItemCreateResource, CartItemResource>
    {
        Task<ActionResult<CartResource>> Scan(string parentId, CartItemCreateScanResource resource);
    }
}
