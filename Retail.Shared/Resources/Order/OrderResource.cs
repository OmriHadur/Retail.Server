using Retail.Shared.Resources.Cart;
using System;
using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources.Order
{
    public class OrderResource : Resource
    {
        public CartResource Cart { get; set; }

        public OrderCustomerResource Customer { get; set; }

        public DateTime Created { get; set; }
        public DeliveryWindowResource DeliveryWindow { get; set; }

        public string Status { get; set; }
    }
}