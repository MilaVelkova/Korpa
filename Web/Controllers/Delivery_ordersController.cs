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
    [Authorize]
    public class Delivery_ordersController : Controller
    {
        private readonly IOrderService _orderService;

        public Delivery_ordersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Delivery_orders
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = _orderService.getShoppingCartInfo(userId);
            return View(dto);
        }   

    }
}
