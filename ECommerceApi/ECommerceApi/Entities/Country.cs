using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
