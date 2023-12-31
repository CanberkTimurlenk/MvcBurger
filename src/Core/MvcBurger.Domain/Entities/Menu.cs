﻿using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class Menu : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }

    }

}
