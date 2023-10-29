using EfCoreDemo.Data;
using EfCoreDemo.Model;
using EfCoreDemo.Models.ViewModels;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
            // 
        }

        public async Task<IActionResult> Index()
        {
            var list = _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.AuthorsBooks).ThenInclude(ab => ab.Author)
                .ToList();

            //foreach (var book in list)
            //{
            //    // book.Publisher = await _context.Publishers.FindAsync(book.Publisher_Id);
            //    await _context.Entry(book).Reference(b => b.Publisher).LoadAsync();
            //    await _context.Entry(book).Collection(b => b.AuthorsBooks).LoadAsync();
            //}

            return View(list);
        }

        public IActionResult Upsert(int? id)
        {
            UpsertBookVM vm = new();
            vm.PublisherList = _context.Publishers.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Publisher_Id.ToString()
            });


            if (id == null || id == 0)
            {
                // Create
                return View(vm);
            }
            else
            {
                // Update
                vm.Book = _context.Books.Find(id);

                if (vm.Book == null) { return NotFound(); }

                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertBookVM vm)
        {
            if (vm.Book.Id == 0)
            {
                // create
                await _context.Books.AddAsync(vm.Book);
            }
            else
            {
                // update
                _context.Books.Update(vm.Book);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            UpsertBookVM obj = new();

            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _context.Books.Include(u => u.BookDetail).FirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(UpsertBookVM obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                //this is create
                _context.BookDetails.Add(obj.Book.BookDetail);
                _context.SaveChanges();

                var BookFromDb = _context.Books.FirstOrDefault(u => u.Id == obj.Book.Id);
                // BookFromDb.BookDetail.BookDetail_Id = obj.Book.BookDetail.BookDetail_Id;
                _context.SaveChanges();
            }
            else
            {
                //this is an update
                _context.BookDetails.Update(obj.Book.BookDetail);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var obj = _context.Books.Find(id);

            if (obj == null) { return NotFound(); };

            _context.Books.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            AuthorBookVM vm = new()
            {
                AuthorBookList = _context.AuthorsBooks
                .Include(u => u.Author).Include(u => u.Book)
                .Where(u => u.BookId == id).ToList(),
                AuthorBookRelation = new() { BookId = id },
                Book = _context.Books.Find(id),
            };

            List<int> tempBookAuthorsIds = vm.AuthorBookList.Select(a => a.BookId).ToList();
            var tempAuthorList = _context.Authors.Where(a => !tempBookAuthorsIds.Contains(a.Author_Id)).ToList();
            vm.AuthorList = tempAuthorList.Select(a => new SelectListItem
            {
                Text = a.FullName,
                Value = a.Author_Id.ToString()
            });

            return View(vm);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageAuthors(AuthorBookVM vm)
        {
            if (vm.AuthorBookRelation.BookId != 0 && vm.AuthorBookRelation.AuthorId != 0)
            {
                _context.AuthorsBooks.Add(vm.AuthorBookRelation);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageAuthors), new { @id = vm.AuthorBookRelation.BookId });
        }

        public async Task<IActionResult> RemoveAuthors(int authorId, AuthorBookVM vm)
        {
            int bookId = vm.Book.Id;
            AuthorBookRelation authorBook = _context.AuthorsBooks.FirstOrDefault(a => a.BookId == bookId && a.AuthorId == authorId);
   
            _context.AuthorsBooks.Remove(authorBook);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public IActionResult PlayGround()
        {
            // No Tracking
            // var genres = _context.Genres.AsNoTracking().ToList();

            // Views
            var view = _context.BookDetailView.ToList();
            var view2 = _context.BookDetailView.Where(b => b.Price < 100).ToList();

            // Raw SQL
            int bookId = 3;
            var bookRaw = _context.Books.FromSqlRaw("SELECT * FROM dbo.Books");
            var bookRaw2 = _context.Books.FromSqlInterpolated($"SELECT * FROM dbo.Books WHERE Id = {bookId}");

            // Stored Procedure
            var bookSp = _context.Books.FromSqlInterpolated($"EXEC getAllBookDetails {bookId}");

            return RedirectToAction(nameof(Index));
        }
    }
}
