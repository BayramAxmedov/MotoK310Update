using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductOtherMenager
    {
        private readonly ApplicationDbContext _context;

        public ProductOtherMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductOther> GetAll()
        {
            return _context.ProductOthers.ToList();
        }

        public ProductOther? GetById(int? id)
        {
            return _context.ProductOthers.Find(id);
        }

        public void AddProductOther(ProductOther productOther)
        {
            _context.ProductOthers.Add(productOther);
            _context.SaveChanges();
        }

        public void UpdateProductOther(ProductOther productOther)
        {
            _context.ProductOthers.Update(productOther);
            _context.SaveChanges();
        }

        public void RemoveProductOther(ProductOther productOther)
        {
            _context.ProductOthers.Remove(productOther);
            _context.SaveChanges();

        }
    }
}
