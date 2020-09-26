using Core.Server.Client.Clients;
using Core.Server.Client.Results;
using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Clients
{
    public class CartItemControllClient : 
        InnerRestClient<CartItemCreateResource, CartItemResource>,
        ICartItemsControllClient
    {
        public CartItemControllClient()
            : base("carts/{0}/items")
        {
        }

        public Task<ActionResult<CartResource>> Scan(string parentId, CartItemCreateScanResource resource)
        {
            return PostAsync<CartResource>(string.Format(ApiUrl, parentId) + "scan", resource);
        }
    }
}