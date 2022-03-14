using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CategoryController : Controller
    {
        private readonly CategoryMenager _categoryMenager;
        private readonly IWebHostEnvironment _env;

        public CategoryController(CategoryMenager categoryMenager, IWebHostEnvironment env)
        {
            _categoryMenager = categoryMenager;
            _env = env;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryMenager.GetAll());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryMenager.GetById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, Category category)
        {

            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                category.PhotoUrl = "/image/" + filename;
            }
            _categoryMenager.AddCategory(category);
            return RedirectToAction("Index");

            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryMenager.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category, IFormFile PhotoUrl)

        {
             ModelState.ClearValidationState("NewPhoto");

            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                category.PhotoUrl = "/image/" + filename;
            }
            _categoryMenager.UpdateCategory(category);
            return RedirectToAction("Index");

            return View();
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = _categoryMenager.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            _categoryMenager.RemoveCategory(category);
            return RedirectToAction("index");
        }
    }
}
