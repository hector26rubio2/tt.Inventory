namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;

    public class InventoryItem : Entity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }

}
