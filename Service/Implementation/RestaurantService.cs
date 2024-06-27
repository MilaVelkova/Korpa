using Domain.Domain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurants> _restaurantRepository;
        private readonly IRepository<Food_items> _fooditemsRepository;

        public RestaurantService(IRepository<Restaurants> restaurantRepository, IRepository<Food_items> fooditemsRepository)
        {
            _restaurantRepository = restaurantRepository;
            _fooditemsRepository = fooditemsRepository;
        }

        public void CreateNewRestaurant(Restaurants restaurant)
        {
            _restaurantRepository.Insert(restaurant);
        }

        public void DeleteRestaurant(Guid id)
        {
            var restaurant = _restaurantRepository.Get(id);
            _restaurantRepository.Delete(restaurant);
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public Restaurants GetDetailsForRestaurant(Guid? id)
        {
            return _restaurantRepository.Get(id);
        }

        public List<Food_items> GetMenu(Guid id)
        {
            List<Food_items> food_Items = _fooditemsRepository.GetAll().ToList();
            List<Food_items> menu = new List<Food_items>();

            foreach (Food_items f in food_Items)
            {
                if (f.RestaurantId == id)
                {
                    menu.Add(f);
                }
            }
            return menu;
        }

        public void UpdateExistingRestaurant(Restaurants restaurant)
        {
            _restaurantRepository.Update(restaurant);
        }
    }
}
