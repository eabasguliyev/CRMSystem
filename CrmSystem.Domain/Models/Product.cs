namespace CrmSystem.Domain.Models
{
    public class Product:DomainObject
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public Company Company { get; set; }
    }
}