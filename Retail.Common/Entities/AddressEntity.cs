using Core.Server.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class AddressEntity : Entity
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [Range(1, 1000)]
        public string HouseNumber { get; set; }

        [Range(1000, 9999999999)]
        public long Zip { get; set; }

        public bool IsPrimary { get; set; }
    }
}
