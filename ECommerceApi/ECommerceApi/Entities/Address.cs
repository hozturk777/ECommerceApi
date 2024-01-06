using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? Adres { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public Order? Order { get; set; }
        public bool IsActive { get; set; }
    }
}
