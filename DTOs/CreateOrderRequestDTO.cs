using EcommerceWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Controllers;
using EcommerceWebAPI.Interface;


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

