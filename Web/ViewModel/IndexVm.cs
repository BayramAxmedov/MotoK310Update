using Entities;

namespace Web.ViewModel
{
    public class IndexVm
    {
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; } 
        public List<SaleProduct> SaleProducts { get; set; }
        public List<Product> Products { get; set; }
        public About Abouts { get; set; }
        public List<ProductOther> ProductOthers { get; set; }
        public List<SliderOther> SliderOthers { get; set; }
    }
}
