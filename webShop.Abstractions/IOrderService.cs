using webShop.Model;

namespace webShop.Abstractions;

public interface IOrderService
{
    public Task<ServiceResult<Order>> PlaceOrderAsync(Order order);
    public Task<ServiceResult<Order>> GetOrderByIdAsync(int id);
    public Task<ServiceResult<Order>> CancelOrderAsync(Order order);
}