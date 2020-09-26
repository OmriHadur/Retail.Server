using Retail.Common.Entities;
using System.Threading.Tasks;

namespace Retail.Common.Helpers
{
    public interface IPromotionsApplayer
    {
        Task ApplayOnItem(CartEntity cartEntity, CartItemEntity cartItemAdded);
    }
}
