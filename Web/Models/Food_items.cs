namespace Web.Models
{
    public class Food_items :BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }

        public virtual ICollection<FoodInShoppingCart> FoodInShoppingCarts { get; set; }

        public virtual IEnumerable<FoodInOrder> FoodInOrders { get; set; }

    }
}
