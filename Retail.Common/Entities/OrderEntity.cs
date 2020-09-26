using Retail.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Retail.Common.Entities
{
    public class OrderEntity : Entity
    {
        [Required]
        public CartEntity Cart { get; set; }

        [Required]
        public AddressEntity Address { get; set; }

        [Required]
        public DateTime Created;

        [Required]
        public string CustomerFullName;

        [Required]
        public DeliveryWindowEntity DeliveryWindow;
        
        public eOrderStatus Status { get; set; }
    }
}
