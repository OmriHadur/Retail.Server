using System;
using System.ComponentModel.DataAnnotations;
using Core.Server.Shared.Resources;

namespace Retail.Standard.Shared.Resources.Order
{
    public class DeliveryWindowCreateResource : CreateResource
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0,23)]
        public int FromHour { get; set; }

        [Required]
        [Range(0, 23)]
        public int ToHour { get; set; }
    }
}