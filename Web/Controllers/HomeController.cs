using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Diagnostics;
using Web.Models;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SliderMenager _sliderMenager;
        private readonly CategoryMenager _categoryMenager;
        private readonly ProductMenager _productMenager;
        private readonly SaleProductMenager _saleProductMenager;
        private readonly ProductOtherMenager _productOtherMenager;
        private readonly SliderOtherMenager _sliderOtherMenager;

        public HomeController(SliderOtherMenager sliderOtherMenager)
        {
            _sliderOtherMenager = sliderOtherMenager;
        }

        public HomeController(ProductOtherMenager productOtherMenager)
        {
            _productOtherMenager = productOtherMenager;
        }

        public HomeController(SaleProductMenager saleProductMenager)
        {
            _saleProductMenager = saleProductMenager;
        }

        public HomeController(ProductMenager productMenager)
        {
            _productMenager = productMenager;
        }

        public HomeController(CategoryMenager categoryMenager)
        {
            _categoryMenager = categoryMenager;
        }

        public HomeController(SliderMenager sliderMenager)
        {
            _sliderMenager = sliderMenager;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexVm vm = new();
            vm.Sliders = _sliderMenager.GetAll();
            vm.Categories = _categoryMenager.GetAll();
            vm.Products = _productMenager.GetAll();
            vm.SaleProducts = _saleProductMenager.GetAll();
            vm.ProductOthers = _productOtherMenager.GetAll();
            vm.SliderOthers = _sliderOtherMenager.GetAll();








            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}