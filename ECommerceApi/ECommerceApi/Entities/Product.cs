using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Cart>? ProductCarts { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
