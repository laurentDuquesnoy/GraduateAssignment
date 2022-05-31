using webShop.Abstractions;
using webShop.Model;

namespace webShop.Services;

public class OrderService : IOrderService
{
    public Task<ServiceResult<Order>> PlaceOrderAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<Order>> GetOrderAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<Order>> CancelOrderAsync()
    {
        throw new NotImplementedException();
    }
}