using AAdminPanel1.Models;
using AAdminPanel1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AAdminPanel1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminContext _adminContext;

        public HomeController(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel()
            {
                Sliders = _adminContext.Sliders.OrderBy(x => x.Order).ToList(),
                FeaturedBooks= _adminContext.Sliders.Include(x=>x.Bookimages).Include(x => x.Authors).Where(x=> x.IsFeatured).ToKist(),
                NewBooks = _adminContext.Sliders.Include(x => x.Bookimages).Include(x => x.Authors).Where(x => x.IsNew).ToKist(),
                DicountedBooks = _adminContext.Sliders.Include(x => x.Bookimages).Include(x => x.Authors).Where(x => x.DicountPrice>0).ToKist()
            };
            return View(homeVM);
        }

       
    }
}