namespace Domain.Models
{
    using Domain.Enums;
    using Transport.Infrastructure.Entities.Impl;
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // El cargo del usuario representado como un enum
        public UserPosition Position { get; set; }

        public ICollection<ProductHistory> ProductHistories { get; set; }
    }
}
