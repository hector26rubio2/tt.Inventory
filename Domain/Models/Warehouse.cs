namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;
    public class Warehouse : Entity
    {
        public string Location { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
