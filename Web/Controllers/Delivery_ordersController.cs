using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;


namespace Web.Controllers
{
    public class Delivery_ordersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Delivery_ordersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Delivery_orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Delivery_Orders.Include(d => d.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Delivery_orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery_orders = await _context.Delivery_Orders
                .Include(d => d.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery_orders == null)
            {
                return NotFound();
            }

            return View(delivery_orders);
        }

        // GET: Delivery_orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Delivery_orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Id")] Delivery_orders delivery_orders)
        {
            if (ModelState.IsValid)
            {
                delivery_orders.Id = Guid.NewGuid();
                _context.Add(delivery_orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", delivery_orders.CustomerId);
            return View(delivery_orders);
        }

        // GET: Delivery_orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery_orders = await _context.Delivery_Orders.FindAsync(id);
            if (delivery_orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", delivery_orders.CustomerId);
            return View(delivery_orders);
        }

        // POST: Delivery_orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerId,Id")] Delivery_orders delivery_orders)
        {
            if (id != delivery_orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery_orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Delivery_ordersExists(delivery_orders.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", delivery_orders.CustomerId);
            return View(delivery_orders);
        }

        // GET: Delivery_orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery_orders = await _context.Delivery_Orders
                .Include(d => d.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery_orders == null)
            {
                return NotFound();
            }

            return View(delivery_orders);
        }

        // POST: Delivery_orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var delivery_orders = await _context.Delivery_Orders.FindAsync(id);
            if (delivery_orders != null)
            {
                _context.Delivery_Orders.Remove(delivery_orders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Delivery_ordersExists(Guid id)
        {
            return _context.Delivery_Orders.Any(e => e.Id == id);
        }
    }
}
