using AAdminPanel1.Models;
using AAdminPanel1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AAdminPanel1.Controllers
{
    public class BookController : Controller
    {
        private readonly AdminContext _adminContext;

        public BookController(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Book book = _adminContext.books.FirstOrDefault(x=>x.Id==id);

            if (book == null) return View("Error");

            BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel
            {
                book = book,
                RelatedBooks= _adminContext.Include(x=>x.BookImages).Include(x => x.Author.FullName).books.Where(x=>x.GenreId == book.GenreId&& x.Id != book.Id).Include(x=>x.BookImages).ToList()
            };

            return View(bookDetailsViewModel);
        }
    }
}
