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
    public class Food_itemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Food_itemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Food_items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Food_Items.ToListAsync());
        }

        // GET: Food_items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food_items = await _context.Food_Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food_items == null)
            {
                return NotFound();
            }

            return View(food_items);
        }

        // GET: Food_items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food_items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Image,Ingredients,Price,Id")] Food_items food_items)
        {
            if (ModelState.IsValid)
            {
                food_items.Id = Guid.NewGuid();
                _context.Add(food_items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food_items);
        }

        // GET: Food_items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food_items = await _context.Food_Items.FindAsync(id);
            if (food_items == null)
            {
                return NotFound();
            }
            return View(food_items);
        }

        // POST: Food_items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Image,Ingredients,Price,Id")] Food_items food_items)
        {
            if (id != food_items.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food_items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Food_itemsExists(food_items.Id))
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
            return View(food_items);
        }

        // GET: Food_items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food_items = await _context.Food_Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food_items == null)
            {
                return NotFound();
            }

            return View(food_items);
        }

        // POST: Food_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var food_items = await _context.Food_Items.FindAsync(id);
            if (food_items != null)
            {
                _context.Food_Items.Remove(food_items);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Food_itemsExists(Guid id)
        {
            return _context.Food_Items.Any(e => e.Id == id);
        }
    }
}
