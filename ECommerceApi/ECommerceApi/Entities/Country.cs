namespace ECommerceApi.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
