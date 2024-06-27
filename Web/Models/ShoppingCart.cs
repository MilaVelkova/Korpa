namespace Web.Models
{
    public class ShoppingCart :BaseEntity
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public virtual ICollection<FoodInShoppingCart> FoodInShoppingCarts { get; set; }

    }
}
