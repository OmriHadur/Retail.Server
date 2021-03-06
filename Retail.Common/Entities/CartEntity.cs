﻿using System.Collections.Generic;
using Core.Server.Common.Entities;

namespace Retail.Common.Entities
{
    public class CartEntity : Entity
    {
        public string CustomerId { get; set; }

        public ICollection<CartItemEntity> Items { get; set; }

        public CartEntity()
        {
            Items = new List<CartItemEntity>();
        }
    }
}
