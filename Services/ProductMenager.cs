using DataAccess;
using Entities;


namespace Services
{
    public class ProductMenager
    {
        private readonly ApplicationDbContext _context;

        public ProductMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.products.ToList();
        }

        public Product? GetById(int? id)
        {
            return _context.products.Find();
        }

        public void AddProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            _context.products.Remove(product);
            _context.SaveChanges();

        }
    }
}
