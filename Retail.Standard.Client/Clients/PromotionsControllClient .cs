using Retail.Standard.Client.Interfaces;
using Retail.Standard.Shared.Resources;

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
