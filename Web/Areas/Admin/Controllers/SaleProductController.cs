using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SaleProductController : Controller
    {
        private readonly ProductMenager _productMenager;
        private readonly SaleProductMenager _saleProductMenager;
        private readonly IWebHostEnvironment _env;

        public SaleProductController(ProductMenager productMenager, IWebHostEnvironment env, SaleProductMenager saleProductMenager)
        {
            _productMenager = productMenager;
            _env = env;
            _saleProductMenager = saleProductMenager;
        }

        // GET: SaleProductController
        public ActionResult Index()
        {
            return View(_saleProductMenager.GetAll());
        }

        // GET: SaleProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _saleProductMenager.GetById(id);
            return View(product);
        }

        // GET: SaleProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleProduct saleProduct)
        {
           
            _saleProductMenager.AddSaleProduct(saleProduct);
            return RedirectToAction("Index");
        }

        // GET: SaleProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var saleProduct = _saleProductMenager.GetById(id);
            return View(saleProduct);
        }

        // POST: SaleProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleProduct saleProduct)
        {
            _saleProductMenager.UpdateSaleProduct(saleProduct);
           return RedirectToAction("Index");
        }

        // GET: SaleProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id==null) return NotFound();
            var saleProduct = _saleProductMenager.GetById(id);
            if (saleProduct != null) return NotFound();
            return View(saleProduct);
        }

        // POST: SaleProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SaleProduct saleProduct)
        {
           _saleProductMenager.RemoveSaleProduct(saleProduct);
            return RedirectToAction("Index");
            
        }
    }
}
