namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<InventoryItem> InventoryItems { get; set; }
        public ICollection<ProductHistory> ProductHistories { get; set; }
    }
}
