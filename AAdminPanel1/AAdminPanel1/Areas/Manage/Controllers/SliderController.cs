using AAdminPanel1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AAdminPanel1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AdminContext _adminContext;

        public SliderController(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _adminContext.Sliders.ToList();
            return View(sliders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            _adminContext.Sliders.Add(slider);
            _adminContext.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _adminContext.Sliders.Find(id);
            if (slider == null) return RedirectToAction("Error");
            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider existSlider = _adminContext.Sliders.Find(slider.Id);
            if (existSlider == null) return RedirectToAction("Error");

            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.Desc = slider.Desc;
            existSlider.RedUrl = slider.RedUrl;
            existSlider.RedUrlText = slider.RedUrlText;
            existSlider.Image = slider.Image;

            _adminContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
