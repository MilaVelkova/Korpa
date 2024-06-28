using Domain.Identity;

namespace Domain.Domain
{
    public class Delivery_orders : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public String? Address { get; set; }
        public IEnumerable<FoodInOrder>? FoodInOrders { get; set; }

    }
}
