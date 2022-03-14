using DataAccess;
using Entities;


namespace Services
{
    public class AboutMenager
    {
        private readonly ApplicationDbContext _context;

        public AboutMenager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<About> GetAll()
        {
            return _context.Abouts.ToList();
        }

        public About? GetById(int? id)
        {
            return _context.Abouts.Find(id);
        }

        public void AddAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
        }

        public void UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
        }

        public void RemoveAbout(About about)
        {
            _context.Abouts.Remove(about);
            _context.SaveChanges();

        }
    }
}
