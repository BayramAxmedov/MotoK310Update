using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ProductOther> ProductOthers { get; set; }
        public DbSet<SliderOther> SliderOthers { get; set; }
    }
}