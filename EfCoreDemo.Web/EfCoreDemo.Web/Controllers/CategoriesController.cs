using EfCoreDemo.Data;
using EfCoreDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categoris = _context.Genres.ToList();
            return View(categoris);
        }

        public IActionResult Upsert(int? id)
        {
            Genre category = new();

            if (id == null || id == 0)
            {
                // Create
                return View(category);
            }
            else
            {
                // Update
                category = _context.Genres.Find(id);

                if (category == null) { return NotFound(); }

                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Genre category) 
        {
            if (ModelState.IsValid) 
            {
                if(category.Id == 0)
                {
                    // create
                    await _context.Genres.AddAsync(category);
                }
                else
                {
                    // update
                    _context.Genres.Update(category);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id == 0) { return NotFound(); }

            var category = _context.Genres.Find(id);

            if(category == null) { return NotFound(); };

            _context.Genres.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2() 
        {
            List<Genre> categories = new List<Genre>();

            for (int i = 1; i <= 2; i++)
            {
                categories.Add(new Genre { Name = $"Genre {i}", DisplayOrder = 100+i });
            }

            await _context.Genres.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            for (int i = 1; i <= 5; i++)
            {
                await _context.Genres.AddAsync(new Genre { Name = $"Genre {i}", DisplayOrder = 100 + i });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            var categories = _context.Genres.OrderByDescending(g => g.Id).Take(2).ToList();

            for (int i = 0; i < categories.Count(); i++)
            {
                _context.Genres.Remove(categories[i]);
            }
            await _context.SaveChangesAsync();
          
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            var categories = _context.Genres.OrderByDescending(g => g.Id).Take(5).ToList();

            _context.Genres.RemoveRange(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
