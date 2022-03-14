using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [MaxLength(350)]
        public string? Description { get; set; }
        public string Price { get; set; }
        public string? DisCount { get; set; }
        [MaxLength(650)]
        public string? PhotoUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool TopSale { get; set; }
        public string? CaregoryId { get; set; }
        public virtual Category? Category { get; set; }
    }

}
