using EcommerceWebAPI.Data;
using EcommerceWebAPI.DTOs;
using EcommerceWebAPI.Entities;
using EcommerceWebAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Service
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderResponseDTO>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .ToListAsync();

            return orders.Select(order => new OrderResponseDTO
            {
                OrderId = order.Id,
                CustomerName = order.Customer.Name,
                TotalPrice = order.TotalPrice,
                Products = order.OrderProducts.Select(op => new OrderProductDetailDTO
                {
                    Name = op.Product.Name,
                    Price = op.UnitPrice,
                    Quantity = op.Quantity
                }).ToList()
            }).ToList();
        }

        public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return new OrderResponseDTO
            {
                OrderId = order.Id,
                CustomerName = order.Customer.Name,
                TotalPrice = order.TotalPrice,
                Products = order.OrderProducts.Select(op => new OrderProductDetailDTO
                {
                    Name = op.Product.Name,
                    Price = op.UnitPrice,
                    Quantity = op.Quantity
                }).ToList()
            };
        }

        public async Task<OrderResponseDTO> PlaceOrderAsync(CreateOrderRequestDTO request)
        {
            var customer = await _context.Customers.FindAsync(request.CustomerId);
            if (customer == null) throw new Exception("Customer not found");

            var order = new Order
            {
                CustomerId = customer.Id,
                OrderProducts = new List<OrderProduct>()
            };

            decimal totalPrice = 0;

            foreach (var item in request.Products)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null) throw new Exception($"Product with ID {item.ProductId} not found");

                if (product.Quantity < item.Quantity)
                    throw new Exception($"Not enough quantity for product {product.Name}");

                product.Quantity -= item.Quantity;

                var orderProduct = new OrderProduct
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                totalPrice += orderProduct.UnitPrice * item.Quantity;
                order.OrderProducts.Add(orderProduct);
            }

            order.TotalPrice = totalPrice;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return await GetOrderByIdAsync(order.Id) ?? throw new Exception("Order not found after creation");
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}