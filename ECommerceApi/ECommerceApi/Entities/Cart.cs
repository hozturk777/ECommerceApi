using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Product>? Products { get; set; }
        public int CustomersId { get; set; }
        public Customer? Customers { get; set; }
    }
}
