using Core.Server.Client.Interfaces;
using Core.Server.Client.Results;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;

namespace Retail.Standard.Client.Interfaces
{
    public interface ICartsControllClient : IRestClient<CartCreateResource, CartResource>
    {
        Task<ActionResult<CartResource>> GetOrCreate(CartCreateResource createResource);

        Task<ActionResult<CartResource>> GetMyCart();

        Task<ActionResult<CartResource>> Assign(string cartId);

        Task<ActionResult<CartResource>> AddOrder(string cartId, string orderId);   
    }
}
