using Core.Server.Client.Clients;
using Core.Server.Client.Results;
using Retail.Client.Interfaces;
using Retail.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Client.Clients
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
