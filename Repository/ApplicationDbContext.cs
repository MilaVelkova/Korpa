using Domain.Domain;
using Domain.Identity;
using Domain.Integration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        private readonly IConfiguration _configuration;
        private bool _usePartnerDatabase;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, bool usePartnerDatabase = false)
            : base(options)
        {
            _configuration = configuration;
            _usePartnerDatabase = usePartnerDatabase;
        }
      

        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Delivery_orders> Delivery_Orders { get; set; }
        public virtual DbSet<Food_items> Food_Items { get; set; }
        public virtual DbSet<FoodInOrder> FoodInOrders { get; set; }
        public virtual DbSet<FoodInShoppingCart> FoodInShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                //this._usePartnerDatabase = true;
                var connectionString = _usePartnerDatabase
                    ? _configuration.GetConnectionString("OtherDatabase")
                    : _configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public void SwitchToPartherDb(bool setToPartherDb)
        {
            this._usePartnerDatabase = setToPartherDb;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
