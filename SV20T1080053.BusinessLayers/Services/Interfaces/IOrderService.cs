using SV20T1080053.DomainModels;

namespace SV20T1080053.BusinessLayers.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(Order order);
    }
}
