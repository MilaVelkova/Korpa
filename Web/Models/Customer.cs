using Microsoft.AspNetCore.Identity;

namespace Web.Models
{
    public class Customer : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Delivery_orders>? Delivery_Orders { get; set; }

    }
}
