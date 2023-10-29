using EfCoreDemo.Data;
using EfCoreDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreDemo.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Authors.ToList();
            return View(list);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new();

            if (id == null || id == 0)
            {
                // Create
                return View(obj);
            }
            else
            {
                // Update
                obj = _context.Authors.Find(id);

                if (obj == null) { return NotFound(); }

                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    // create
                    await _context.Authors.AddAsync(obj);
                }
                else
                {
                    // update
                    _context.Authors.Update(obj);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var obj = _context.Authors.Find(id);

            if (obj == null) { return NotFound(); };

            _context.Authors.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
