
using Microsoft.AspNetCore.Mvc;
using EcommerceWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Interface;

//home... let me go home, home is where ever im with you

namespace EcommerceWebAPI.DTOs
{
    public class CreateOrderRequestDTO
    {
        public int CustomerId { get; set; }
        public List<OrderItemDTO> Products { get; set; } = new();
    }

    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

