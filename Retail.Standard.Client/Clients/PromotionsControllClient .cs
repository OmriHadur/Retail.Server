using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;
using Core.Server.Client.Clients;

namespace Retail.Standard.Client.Clients
{
    public class PromotionsControllClient :
        RestClient<PromotionCreateResource, PromotionResource>,
        IPromotionsControllClient
    {
        public PromotionsControllClient()
            :base( "promotions")
        {
        }
    }
}
