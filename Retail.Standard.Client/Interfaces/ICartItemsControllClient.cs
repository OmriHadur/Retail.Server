using Retail.Standard.Client.Results;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Interfaces
{
    public interface ICartItemsControllClient : IInnerRestClient<CartItemCreateResource, CartItemResource>
    {
        Task<ActionResult<CartResource>> Scan(string parentId, CartItemCreateScanResource resource);
    }
}
