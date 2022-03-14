namespace Entities
{
    public class SaleProduct : BaseEntity
    {
        public bool IsEnable { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
