using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int? CartsId { get; set; }
        public Cart? Carts { get; set; }
        public int? CustomersId { get; set; }
        public Customer? Customers { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
