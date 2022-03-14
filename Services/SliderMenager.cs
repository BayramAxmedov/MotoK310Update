using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SliderMenager
    {
        private readonly ApplicationDbContext _context;

        public SliderMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Slider> GetAll()
        {
            return _context.Sliders.ToList();
        }

        public Slider? GetById(int? id)
        {
            return _context.Sliders.Find(id);
        }

        public void AddSlider(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
        }

        public void UpdateSlider(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
        }

        public void RemoveSlider(Slider slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();

        }
    }
}
