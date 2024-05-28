using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Implementions;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.BusinessLayers.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderRepository _orderRepository;
       
        public OrderService(ILogger<OrderService> logger, IHttpContextAccessor httpContextAccessor, IOrderRepository orderRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();
                if (orders == null)
                {
                    throw new Exception("Không có đơn nào!");
                }
                return orders;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error: {e.Message}");
                throw;
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            try
            {

                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy đơn thuê với ID {id}.");
                }
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy đơn thuê theo ID: {ex.Message}");
                throw;
            }
        }

        public Task<Order> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
