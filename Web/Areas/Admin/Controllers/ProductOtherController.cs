using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductOtherController : Controller
    {
        private readonly ProductOtherMenager _productOtherMenager;
        private readonly IWebHostEnvironment _env;

        public ProductOtherController(ProductOtherMenager productOtherMenager, IWebHostEnvironment env)
        {
            _productOtherMenager = productOtherMenager;
            _env = env;
        }

        // GET: ProductOtherController
        public ActionResult Index()
        {
            return View(_productOtherMenager.GetAll());
        }

        // GET: ProductOtherController/Details/5
        public ActionResult Details(int id)
        {
            var productOther = _productOtherMenager.GetById(id);
            return View();
        }

        // GET: ProductOtherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOtherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, ProductOther productOther)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                productOther.PhotoUrl = "/image/" + filename;
            }
            _productOtherMenager.AddProductOther(productOther);
            return RedirectToAction("Index");
            return View();

        }

        // GET: ProductOtherController/Edit/5
        public ActionResult Edit(int id)
        {
            var productOther = _productOtherMenager.GetById(id);
            return View();
        }

        // POST: ProductOtherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormFile PhotUrl, ProductOther productOther)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (PhotUrl == null)
            {
                string filename = Guid.NewGuid() + PhotUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photopath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photopath, FileMode.Create);
                PhotUrl.CopyTo(fl);
                productOther.PhotoUrl = "/image/" + filename;
            }
            _productOtherMenager.UpdateProductOther(productOther);
            return RedirectToAction("index");
            return View();

        }

        // GET: ProductOtherController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var productOther = _productOtherMenager.GetById(id);
            if(productOther == null) return NotFound();
            return View(productOther);
        }

        // POST: ProductOtherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductOther productOther)
        {
            _productOtherMenager.RemoveProductOther(productOther);
            return RedirectToAction("index");
            
        }
    }
}
