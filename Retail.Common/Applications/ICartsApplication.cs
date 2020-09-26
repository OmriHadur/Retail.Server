using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources.Cart;
using System.Threading.Tasks;
using Core.Server.Common.Applications;

namespace Retail.Common.Applications
{
    public interface ICartsApplication : IRestApplication<CartCreateResource, CartResource>
    {
        Task<ActionResult<CartResource>> GetOrCreate(CartCreateResource createResource);
        Task<ActionResult<CartResource>> Assign(string cartId);
        Task<ActionResult<CartResource>> AddOrder(string cartId, string orderId);
        Task<ActionResult<CartResource>> GetMyCart();
    }
}
