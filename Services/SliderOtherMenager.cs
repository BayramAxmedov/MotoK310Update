using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SliderOtherMenager
    {
        private readonly ApplicationDbContext _context;

        public SliderOtherMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SliderOther> GetAll()
        {
            return _context.SliderOthers.ToList();
        }

        public SliderOther? GetById(int? id)
        {
            return _context.SliderOthers.Find(id);
        }

        public void AddSliderOther(SliderOther sliderOther)
        {
            _context.SliderOthers.Add(sliderOther);
            _context.SaveChanges();
        }

        public void UpdateSliderOther(SliderOther sliderOther)
        {
            _context.SliderOthers.Update(sliderOther);
            _context.SaveChanges();
        }

        public void RemoveSliderOther(SliderOther sliderOther)
        {
            _context.SliderOthers.Remove(sliderOther);
            _context.SaveChanges();

        }
    }
}
