using System;

namespace Retail.Standard.Shared.Resources.Order
{
    public class DeliveryWindowResource : Resource
    {
        public DateTime Date { get; set; }
        public int FromHour { get; set; }
        public int ToHour { get; set; }
        public bool IsAvailable { get; set; }
    }
}