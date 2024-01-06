using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
