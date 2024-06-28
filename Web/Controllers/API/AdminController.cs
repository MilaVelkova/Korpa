using Domain.Domain;
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
        private readonly UserManager<Customer> _userManager;
        public AdminController(IRestaurantService restaurantService, UserManager<Customer> userManager)
        {
            _restaurantService = restaurantService;
            _userManager = userManager;
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
    }
}
