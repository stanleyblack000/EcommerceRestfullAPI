using EcommerceWebAPI.DTOs;

namespace EcommerceWebAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }  // Foreign key

        public Customer Customer { get; set; }

        public List<OrderItemDTO> Products { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public decimal TotalPrice { get; set; }
    }
}
