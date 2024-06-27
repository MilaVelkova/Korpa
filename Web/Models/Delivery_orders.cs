﻿namespace Web.Models
{
    public class Delivery_orders : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<FoodInOrder>? FoodInOrders { get; set; }

    }
}
