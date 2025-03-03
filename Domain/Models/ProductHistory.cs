namespace Domain.Models
{
    using Domain.Enums;
    using Transport.Infrastructure.Entities.Impl;
    public class ProductHistory : Entity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public ActionType Action { get; set; } // Using enum for action type
        public DateTime ChangedAt { get; set; }
        public string? ChangedBy { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
