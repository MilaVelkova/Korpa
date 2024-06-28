namespace Domain.Domain
{
    public class FoodInShoppingCart : BaseEntity
    {
        public Guid Food_ItemsId { get; set; }
        public Food_items? Food_Items { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurants? Restaurant { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }

    }
}
