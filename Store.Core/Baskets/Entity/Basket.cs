using System;
using System.Collections.Generic;

namespace Store.Core.CustomerBaskets.Entity
{
    public class Basket
    {
        public Basket()
        {
                
        }

        public Basket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
