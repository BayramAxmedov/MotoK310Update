using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SliderController : Controller
    {
        private readonly SliderMenager _sliderMenager;
        private readonly IWebHostEnvironment _env;

        public SliderController(SliderMenager sliderMenager, IWebHostEnvironment env)
        {
            _sliderMenager = sliderMenager;
            _env = env;
        }


        // GET: SliderController
        public ActionResult Index()
        {
            return View(_sliderMenager.GetAll());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            var slider = _sliderMenager.GetById(id);
            return View(slider);
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, Slider slider)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                slider.PhotoUrl = "/image/" + filename;
            }
            _sliderMenager.AddSlider(slider);
            return RedirectToAction("Index");
            return View();
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var slider = _sliderMenager.GetById(id);
            return View(slider);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Slider slider, IFormFile PhotoUrl)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                slider.PhotoUrl = "/image/" + filename; 
            }
            _sliderMenager.UpdateSlider(slider);
            return RedirectToAction("index");
            return View();
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var slider = _sliderMenager.GetById(id);
            if (slider == null) return NotFound();
            return View();
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Slider slider)
        {
            _sliderMenager.RemoveSlider(slider);
            return RedirectToAction("index");
        }
    }
}
