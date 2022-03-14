using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly ProductMenager _productMenager;
        private readonly IWebHostEnvironment _env;

        public ProductController(ProductMenager productMenager, IWebHostEnvironment env)
        {
            _productMenager = productMenager;
            _env = env;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productMenager.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _productMenager.GetById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl, Product product)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string photoPath = Path.Combine(rootPath,filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                product.PhotoUrl = "/image/" + filename;
            }
            _productMenager.AddProduct(product);
            return RedirectToAction("Index");   
            return View();  
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productMenager.GetById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product,IFormFile Photourl)
        {
            ModelState.ClearValidationState("NewPhoto");
            if(Photourl != null)
            {
                string filename = Guid.NewGuid() + Photourl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string potoPath = Path.Combine(rootPath,filename);
                using FileStream fl = new (potoPath, FileMode.Create);
                Photourl.CopyTo(fl);
                product.PhotoUrl = "/image/" + filename;
            }
            _productMenager.UpdateProduct(product);
            return RedirectToAction("Index");
            return View();

        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var product = _productMenager.GetById(id);
            if(product == null) return NotFound();
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            _productMenager.RemoveProduct(product);
            return RedirectToAction("Index");
        }
    }
}
