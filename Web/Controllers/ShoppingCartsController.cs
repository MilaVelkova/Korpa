using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository;
using Service.Interface;


namespace Web.Controllers
{
    [Authorize]
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService _shoppingCartService)
        {
            this._shoppingCartService = _shoppingCartService;
        }

        // GET: ShoppingCarts
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = _shoppingCartService.getShoppingCartInfo(userId);
            return View(dto);
        }

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.deleteProductFromShoppingCart(userId, id);

            return RedirectToAction("Index");

        }
        public IActionResult IncreaseProductQantity(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.IncreaseQantityForProduct(userId, id);

            return RedirectToAction("Index");

        }
        public IActionResult DecreaseProductQantity(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.DecreaseQantityForProduct(userId, id);

            return RedirectToAction("Index");

        }


        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Order_Confirm(String Address)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _shoppingCartService.order(userId ?? "", Address);

            return RedirectToAction("Index", "ShoppingCarts");
        }


    }
}
