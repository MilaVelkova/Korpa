namespace Domain.Domain
{
    public class FoodInOrder :BaseEntity
    {
        public Guid FoodId { get; set; }
        public Food_items Food_Items { get; set; }
        public Guid OrderId { get; set; }
        public Delivery_orders Delivery_Orders { get; set; }
        public int Quantity { get; set; }

    }
}
