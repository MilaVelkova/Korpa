using Domain.Domain;
using Domain.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IFoodItemService _foodItemService;
        private readonly UserManager<Customer> _userManager;
        public AdminController(IRestaurantService restaurantService, UserManager<Customer> userManager,
            IFoodItemService foodItemService)
        {
            _restaurantService = restaurantService;
            _userManager = userManager;
            _foodItemService = foodItemService;
        }
        [HttpGet("[action]")]
        public List<Restaurants> GetAllRestaurants()
        {
            return this._restaurantService.GetAllRestaurants();
        }

        [HttpPost("[action]")]
        public void CreateRestaurants(Restaurants restaurant)
        {
            _restaurantService.CreateNewRestaurant(restaurant);
        }

        [HttpPost("[action]")]
        public Restaurants GetDetails(BaseEntity id)
        {
            return this._restaurantService.GetDetailsForRestaurant(id);
        }

        [HttpPost("[action]")]
        public void EditRestaurant(Restaurants restaurant)
        {
            _restaurantService.UpdateExistingRestaurant(restaurant);
        }

        [HttpPost("[action]")]
        public void Delete(Restaurants restaurant)
        {
            _restaurantService.DeleteRestaurant(restaurant.Id);
        }
        [HttpPost("[action]")]
        public List<Food_items> GetMenu(BaseEntity model)
        {
            return _restaurantService.GetMenu(model.Id);
        }
               
        [HttpPost("[action]")]
        public void CreateFoodItem(FoodDto food)
        {
            Food_items foodItem = new Food_items()
            {
                Id = food.Id,
                Name = food.Name,
                Image = food.Image,
                Ingredients = food.Ingredients,
                Price = food.Price,
                RestaurantId = food.RestaurantId
            };
            _foodItemService.CreateNewFood(foodItem);
        }

        [HttpPost("[action]")]
        public Food_items GetDetailsFood(BaseEntity id)
        {
            return _foodItemService.GetDetailsForFood(id.Id);
        }

        [HttpPost("[action]")]
        public void EditFood(Food_items food)
        {
            _foodItemService.UpdateExistingFood(food);
        }
        [HttpPost("[action]")]
        public void DeleteFood(BaseEntity model)
        {
            _foodItemService.DeleteFood(model.Id);
        }
    }
}
