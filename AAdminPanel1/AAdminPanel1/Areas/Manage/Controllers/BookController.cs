using AAdminPanel1.Models;
using AAdminPanel1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AAdminPanel1.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly AdminContext _adminContext;

        public BookController(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public IActionResult Index()
        {


            return View(_adminContext.books.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Authors= _adminContext.authors.ToList();
            ViewBag.Genres= _adminContext.genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel bookVM) 
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            Book book = new Book
            {
                Name= bookVM.Name,
                CostPrice= bookVM.CostPrice,
                SalePrice= bookVM.SalePrice,
                DiscountPrice= bookVM.DiscountPrice,
                GenreId= bookVM.GenreId,
                AuthorId= bookVM.AuthorId,
                ProductCode= bookVM.ProductCode,
                Desc = bookVM.Desc,
                IsAvailable= bookVM.IsAvailable,
                
            };
            _adminContext.books.Add(book);
            _adminContext.SaveChanges();
            return RedirectToAction(nameof("Index"));
        }

        public IActionResult Update(int id)
        {
            ViewBag.Authors = _adminContext.authors.ToList();
            ViewBag.Genres = _adminContext.genres.ToList();

            Book book = _adminContext.books.Find(id);

            if(book == null) return View("Error");
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id,BookCreateViewModel book)
        {
            ViewBag.Authors = _adminContext.authors.ToList();
            ViewBag.Genres = _adminContext.genres.ToList();

            Book existBook = _adminContext.books.FirstOrDefault(x => x.Id == id);
            if(book == null) return View("Error");
            if(!ModelState.IsValid) return View();


            existBook.Name = book.Name;
            existBook.AuthorId = book.AuthorId;
            existBook.Desc = book.Desc;
            existBook.IsAvailable = book.IsAvailable;
            existBook.SalePrice = book.SalePrice;
            existBook.CostPrice = book.CostPrice;
            existBook.DiscountPrice = book.DiscountPrice;
            existBook.ProductCode= book.ProductCode;
            existBook.GenreId= book.GenreId;

            _adminContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
