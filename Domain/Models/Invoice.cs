namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;

    public class Invoice : Entity
    {
        public DateTime IssueDate { get; set; }
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }
        public string? Details { get; set; }
    }
}
