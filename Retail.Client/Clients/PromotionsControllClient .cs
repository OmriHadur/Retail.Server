using Retail.Client.Interfaces;
using Retail.Shared.Resources;
using Core.Server.Client.Clients;

namespace Retail.Client.Clients
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
