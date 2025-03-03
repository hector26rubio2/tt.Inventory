namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;
    public class Store : Entity
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // Navigation property to the associated Warehouse.
        public Warehouse Warehouse { get; set; }
    }
}
