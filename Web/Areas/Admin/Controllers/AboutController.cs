using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]

    public class AboutController : Controller
    {
        private readonly AboutMenager _aboutMenager;
        private readonly IWebHostEnvironment _env;

        public AboutController(AboutMenager aboutMenager, IWebHostEnvironment env)
        {
            _aboutMenager = aboutMenager;
            _env = env;
        }

        // GET: AboutController
        public ActionResult Index()
        {
            return View(_aboutMenager.GetAll());
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {
            var about = _aboutMenager.GetById(id);
            return View(about);
        }

        // GET: AboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, About about)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                about.PhotoUrl = "/image/" + filename;
            }
            _aboutMenager.AddAbout(about);
            return RedirectToAction("Index");
            return View();

        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            var about = _aboutMenager.GetById(id);
            return View();
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormFile PhotoUrl, About about)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                about.PhotoUrl = "/image/" + filename;
            }
            _aboutMenager.UpdateAbout(about);
            return RedirectToAction("Index");
            return View();

        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null) return NotFound  ();
            var about = _aboutMenager.GetById(id);
            if(about == null) return NotFound ();
            return View(about);
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(About about)
        {
           _aboutMenager.RemoveAbout(about);
            return RedirectToAction("Index");
        }
    }
}
