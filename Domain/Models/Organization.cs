namespace Domain.Models
{
    using Transport.Infrastructure.Entities.Impl;
    public class Organization : Entity
    {
        public string Name { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
