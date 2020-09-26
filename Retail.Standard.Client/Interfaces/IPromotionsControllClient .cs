using Core.Server.Client.Interfaces;
using Retail.Standard.Shared.Resources;

namespace Retail.Standard.Client.Interfaces
{
    public interface IPromotionsControllClient : IRestClient<PromotionCreateResource, PromotionResource>
    {

    }
}
