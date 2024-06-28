using Domain.Domain;
using Domain.DTO;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _userRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        

        public Delivery_orders GetDetailsForOrder(BaseEntity id)
        {
            return _orderRepository.GetDetailsForOrder(id);
        }

        public List<Delivery_orders> getShoppingCartInfo(string userId)
        {

            List<Delivery_orders> all_orders = _orderRepository.GetAllOrders();
            List<Delivery_orders> order_for_user = new List<Delivery_orders>();
            var loggedInUser = _userRepository.Get(userId);

            foreach (Delivery_orders order in all_orders)
            {
                if (order.Customer == loggedInUser)
                {
                    order_for_user.Add(order);
                }
            }

            //var totalPrice = order_for_user.Select().Select(x => (x.Food_Items.Price * x.Quantity)).Sum();

  
            return order_for_user;
        }
    }
}
