using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleProductMenager
    {
        private readonly ApplicationDbContext _context;
        public SaleProductMenager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SaleProduct> GetAll()
        {
            return _context.SaleProduct.ToList();
        }

        public SaleProduct? GetById(int? id)
        {
            return _context.SaleProduct.Find();
        }

        public void AddSaleProduct(SaleProduct  saleProduct)
        {
            _context.SaleProduct.Add(saleProduct);
            _context.SaveChanges();
        }

        public void UpdateSaleProduct(SaleProduct saleProduct)
        {
            _context.SaleProduct.Update(saleProduct);
            _context.SaveChanges();
        }

        public void RemoveSaleProduct(SaleProduct saleProduct)
        {
            _context.SaleProduct.Remove(saleProduct);
            _context.SaveChanges();

        }

    }
}
