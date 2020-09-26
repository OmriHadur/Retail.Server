using Retail.Standard.Client.Interfaces;
using Retail.Standard.Client.Results;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Clients
{
    public class CartsControllClient :
        RestClient<CartCreateResource, CartResource>,
        ICartsControllClient
    {
        public CartsControllClient()
            : base("carts")
        {
        }

        public Task<ActionResult<CartResource>> AddOrder(string cartId, string orderId)
        {
            return PutAsync<CartResource>($"{ApiUrl}{cartId}/addorder/{orderId}", null);
        }

        public Task<ActionResult<CartResource>> Assign(string cartId)
        {
            return PutAsync<CartResource>($"{ApiUrl}{cartId}/assign", null);
        }

        public Task<ActionResult<CartResource>> GetMyCart()
        {
            return GetAsync<CartResource>($"{ApiUrl}my");
        }

        public Task<ActionResult<CartResource>> GetOrCreate(CartCreateResource createResource)
        {
            return PostAsync<CartResource>($"{ApiUrl}getorcreate", createResource);
        }
    }
}
