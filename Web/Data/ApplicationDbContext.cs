using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Delivery_orders> Delivery_Orders { get; set; }
        public virtual DbSet<Food_items> Food_Items { get; set; }
        public virtual DbSet<FoodInOrder> FoodInOrders { get; set; }
        public virtual DbSet<FoodInShoppingCart> FoodInShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}
