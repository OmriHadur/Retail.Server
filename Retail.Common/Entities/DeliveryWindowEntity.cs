using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Core.Server.Common.Entities;

namespace Retail.Common.Entities
{
    public class DeliveryWindowEntity : Entity
    {
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime Date { get; set; }
        public int FromHour { get; set; }
        public int ToHour { get; set; }

        public ICollection<DeliveryWindowOrderEntity> Orders { get; set; }

        public DeliveryWindowEntity()
        {
            Orders = new List<DeliveryWindowOrderEntity>();
        }
    }
}
