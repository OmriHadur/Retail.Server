using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources
{
    public class AddressResource : Resource
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public long Zip { get; set; }
    }
}