namespace Domain.Domain
{
    public class Food_items :BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurants Restaurant { get; set; }

        public virtual ICollection<FoodInShoppingCart> FoodInShoppingCarts { get; set; }

        public virtual IEnumerable<FoodInOrder> FoodInOrders { get; set; }

    }
}
