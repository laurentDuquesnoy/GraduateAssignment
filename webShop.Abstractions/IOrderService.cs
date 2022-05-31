using webShop.Model;

namespace webShop.Abstractions;

public interface IOrderService
{
    public Task<ServiceResult<Order>> PlaceOrderAsync();
    public Task<ServiceResult<Order>> GetOrderAsync();
    public Task<ServiceResult<Order>> CancelOrderAsync();
}