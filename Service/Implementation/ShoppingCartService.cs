using Domain.Domain;
using Domain.DTO;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<FoodInShoppingCart> _FoodInShoppingCartRepository;
        private readonly ICustomerRepository _userRepository;
        private readonly IRepository<Delivery_orders> _orderRepository;
        private readonly IRepository<FoodInOrder> _productInOrderRepository;

        public ShoppingCartService (IRepository<ShoppingCart> shoppingCartRepository, IRepository<FoodInShoppingCart> foodInShoppingCartRepository, ICustomerRepository userRepository, IRepository<Delivery_orders> orderRepository, IRepository<FoodInOrder> productInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _FoodInShoppingCartRepository = foodInShoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
        }

        public bool AddToShoppingConfirmed(FoodInShoppingCart model, string userId)
        {

            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser.ShoppingCart;

            if (userShoppingCart.FoodInShoppingCarts == null)
                userShoppingCart.FoodInShoppingCarts = new List<FoodInShoppingCart>(); ;
            var item = userShoppingCart.FoodInShoppingCarts.FirstOrDefault(x => x.Food_ItemsId == model.Food_ItemsId);
            if (item != null)
            {
                item.Quantity += model.Quantity;
            }
            else
            {
                userShoppingCart.FoodInShoppingCarts.Add(model);
            }
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        

        public bool deleteProductFromShoppingCart(string userId, Guid productId)
        {
            if (productId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;
                var product = userShoppingCart.FoodInShoppingCarts.Where(x => x.Food_ItemsId == productId).FirstOrDefault();

                userShoppingCart.FoodInShoppingCarts.Remove(product);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;

        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            var allProduct = userShoppingCart?.FoodInShoppingCarts?.ToList();

            var totalPrice = allProduct.Select(x => (x.Food_Items.Price * x.Quantity)).Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Products = allProduct,
                TotalPrice = totalPrice
            };
            return dto;
        }

        public bool IncreaseQantityForProduct(string userId, Guid productId)
        {
            if (productId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;
                var product = userShoppingCart.FoodInShoppingCarts.Where(x => x.Food_ItemsId == productId).FirstOrDefault();

                product.Quantity++;

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;
        }

        public bool DecreaseQantityForProduct(string userId, Guid productId)
        {
            if (productId != null)
            {
                var loggedInUser = _userRepository.Get(userId);
                var userShoppingCart = loggedInUser.ShoppingCart;
                var product = userShoppingCart.FoodInShoppingCarts.Where(x => x.Food_ItemsId == productId).FirstOrDefault();
                if (product.Quantity-1 > 0)
                {
                    product.Quantity--;
                }
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;
        }

        public bool order(string userId, string Address)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;

                Delivery_orders order = new Delivery_orders
                {
                    Id = Guid.NewGuid(),
                    CustomerId = userId,
                    Customer = loggedInUser,
                    Address = Address
                };

                _orderRepository.Insert(order);

                List<FoodInOrder> productInOrder = new List<FoodInOrder>();

                var lista = userShoppingCart.FoodInShoppingCarts.Select(
                    x => new FoodInOrder
                    {
                        Id = Guid.NewGuid(),
                        Food_ItemsId = x.Food_Items.Id,
                        Food_Items = x.Food_Items,
                        Delivery_OrdersId = order.Id,
                        Delivery_Orders = order,
                        Quantity = x.Quantity
                    }
                    ).ToList();


                StringBuilder sb = new StringBuilder();

                var totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order conatins: ");

                for (int i = 1; i <= lista.Count(); i++)
                {
                    var currentItem = lista[i - 1];
                    totalPrice += currentItem.Quantity * currentItem.Food_Items.Price;
                    sb.AppendLine(i.ToString() + ". " + currentItem.Food_Items.Name + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Food_Items.Price);
                }

                sb.AppendLine("Total price for your order: " + totalPrice.ToString());
                //message.Content = sb.ToString();

                productInOrder.AddRange(lista);

                foreach (var product in productInOrder)
                {
                    _productInOrderRepository.Insert(product);
                }

                loggedInUser.ShoppingCart.FoodInShoppingCarts.Clear();
                _userRepository.Update(loggedInUser);
               // this._emailService.SendEmailAsync(message);

                return true;
            }
            return false;
        }
    }
}
