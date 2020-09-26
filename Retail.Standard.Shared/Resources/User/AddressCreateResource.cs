using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Retail.Standard.Shared.Resources
{
    public class AddressCreateResource : CreateResource
    {
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [Range(1, 1000)]
        public int HouseNumber { get; set; }

        [Range(1000,9999999999)]
        public long Zip { get; set; }
        public bool IsPrimary { get; set; }
    }
}