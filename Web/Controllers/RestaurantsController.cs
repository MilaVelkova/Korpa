using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;


namespace Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IFoodItemService _foodItemService;

        public RestaurantsController(IRestaurantService restaurantService, IShoppingCartService shoppingCartService, IFoodItemService foodItemService)
        {
            _restaurantService = restaurantService;
            _shoppingCartService = shoppingCartService;
            _foodItemService=foodItemService;
        }

        // GET: Restaurants
        public IActionResult Index()
        {
            return View(_restaurantService.GetAllRestaurants());
        }

        // GET: Restaurants/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = _restaurantService.GetDetailsForRestaurant(id);
            if (restaurants == null)
            {
                return NotFound();
            }

            return View(restaurants);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Image,Location,Id")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                restaurants.Id = Guid.NewGuid();
                _restaurantService.CreateNewRestaurant(restaurants);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = _restaurantService.GetDetailsForRestaurant(id);
            if (restaurants == null)
            {
                return NotFound();
            }
            return View(restaurants);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Image,Location,Id")] Restaurants restaurants)
        {
            if (id != restaurants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _restaurantService.UpdateExistingRestaurant(restaurants);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantsExists(restaurants.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }

        // GET: Restaurants/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = _restaurantService.GetDetailsForRestaurant(id);
            if (restaurants == null)
            {
                return NotFound();
            }

            return View(restaurants);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var restaurants = _restaurantService.GetDetailsForRestaurant(id);
            if (restaurants != null)
            {
                _restaurantService.DeleteRestaurant(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantsExists(Guid id)
        {
            return _restaurantService.GetDetailsForRestaurant(id) != null;
        }




        public IActionResult Menu(Guid id)
        {
            return View(_restaurantService.GetMenu(id));
        }

        [Authorize]
        public IActionResult Add_to_cart(Guid? id, Guid? retaurantid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retaurant = _restaurantService.GetDetailsForRestaurant(retaurantid);
            var food = _foodItemService.GetDetailsForFood(id);
            

            FoodInShoppingCart ps = new FoodInShoppingCart();

            if (retaurant != null)
            {
                ps.Food_ItemsId = (Guid)id;
                ps.RestaurantId = (Guid)retaurantid;
                ps.Food_Items = food;

            }

            return View(ps);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(FoodInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddToShoppingConfirmed(model, userId);

            return RedirectToAction("Menu",new {id=model.RestaurantId});
        }

    }
}
