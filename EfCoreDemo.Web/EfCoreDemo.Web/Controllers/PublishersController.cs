using EfCoreDemo.Data;
using EfCoreDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using Publisher = EfCoreDemo.Model.Publisher;

namespace EfCoreDemo.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublishersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Publishers.ToList();
            return View(list);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher obj = new();

            if (id == null || id == 0)
            {
                // Create
                return View(obj);
            }
            else
            {
                // Update
                obj = _context.Publishers.Find(id);

                if (obj == null) { return NotFound(); }

                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    // create
                    await _context.Publishers.AddAsync(obj);
                }
                else
                {
                    // update
                    _context.Publishers.Update(obj);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var obj = _context.Publishers.Find(id);

            if (obj == null) { return NotFound(); };

            _context.Publishers.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
