namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;
    public class Sale : Entity
    {
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        // Navigation property for the associated Invoice.
        public Invoice Invoice { get; set; }
    }
}
