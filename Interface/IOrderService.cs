using Microsoft.AspNetCore.Mvc;
using EcommerceWebAPI.Service;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.DTOs;

namespace EcommerceWebAPI.Interface
{
    public interface IOrderService
    {
        Task<List<OrderResponseDTO>> GetAllOrdersAsync();
        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
        Task<OrderResponseDTO> PlaceOrderAsync(CreateOrderRequestDTO request);
        Task<bool> DeleteOrderAsync(int id);
    }
}
