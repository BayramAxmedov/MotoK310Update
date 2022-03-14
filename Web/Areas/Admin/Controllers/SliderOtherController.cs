using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SliderOtherController : Controller
    {
        private readonly SliderOtherMenager _sliderOtherMenager;
        private readonly IWebHostEnvironment _env;

        public SliderOtherController(SliderOtherMenager sliderOtherMenager, IWebHostEnvironment env)
        {
            _sliderOtherMenager = sliderOtherMenager;
            _env = env;
        }

        // GET: SliderOtherController
        public ActionResult Index()
        {
            return View(_sliderOtherMenager.GetAll());
        }

        // GET: SliderOtherController/Details/5
        public ActionResult Details(int id)
        {
            var sliderOther = _sliderOtherMenager.GetById(id);
            return View();
        }

        // GET: SliderOtherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderOtherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, SliderOther sliderOther)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                sliderOther.PhotoUrl = "/image/" + filename;
            }
            _sliderOtherMenager.AddSliderOther(sliderOther);
            return RedirectToAction("Index");
            return View();

        }

        // GET: SliderOtherController/Edit/5
        public ActionResult Edit(int id)
        {
            var sliderOther = _sliderOtherMenager.GetById(id);
            return View();
        }

        // POST: SliderOtherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormFile PhotoUrl, SliderOther sliderOther)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (PhotoUrl == null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(rootPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                sliderOther.PhotoUrl = "/image/" + filename;
            }
            _sliderOtherMenager.UpdateSliderOther(sliderOther);
            return RedirectToAction("index");
            return View();

        }

        // GET: SliderOtherController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var sliderOther = _sliderOtherMenager.GetById(id);
            if(sliderOther == null) return NotFound();
            return View(sliderOther);
        }

        // POST: SliderOtherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SliderOther sliderOther)
        {
            _sliderOtherMenager.RemoveSliderOther(sliderOther);
                return RedirectToAction("index");
            
        }
    }
}
