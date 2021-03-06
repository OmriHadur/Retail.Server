using Core.Server.Shared.Resources;

namespace Retail.Shared.Resources
{
    public class AddressResource : Resource
    {
        public string UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public long Zip { get; set; }
    }
}