using EcommerceWebAPI.Service;
using EcommerceWebAPI.Controllers;
using EcommerceWebAPI.Data;


namespace EcommerceWebAPI.DTOs
{
    public class OrderResponseDTO
    {
   
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public decimal TotalPrice { get; set; }
            public List<OrderProductDetailDTO> Products { get; set; }
        }

        public class OrderProductDetailDTO
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    
}
