using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryMenager
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int? id)
        {
            return _context.Categories.Find(id);
        }

        public void AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            _context.SaveChanges();
        }

        public void RemoveCategory(Category Category)
        {
            _context.Categories.Remove(Category);
            _context.SaveChanges();

        }
    }
}
