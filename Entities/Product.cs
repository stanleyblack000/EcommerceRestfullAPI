using System.ComponentModel.DataAnnotations;

namespace EcommerceWebAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        // Navigation for many-to-many
        public List<OrderProduct> OrderProducts { get; set; } = new();

        // Parameterless constructor for EF
        public Product() { }

        public Product(int id, string name, string desc, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Description = desc;
            Price = price;
            Quantity = quantity;
        }
    }
}
