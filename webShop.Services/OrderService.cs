using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;
using webShop.Model;
using webShop.Repository;

namespace webShop.Services;

public class OrderService : IOrderService
{
    private readonly WebShopDbContext _webShopDbContext;

    public OrderService(WebShopDbContext webShopDbContext)
    {
        _webShopDbContext = webShopDbContext;
    }
    public async Task<ServiceResult<Order>> PlaceOrderAsync(Order order)
    {
        var lastOrderByUser = await
            _webShopDbContext.Orders.Where(x => x.Customer == order.Customer)
                .OrderByDescending(x => x.TimeStamp)
                .FirstOrDefaultAsync();
        if (lastOrderByUser?.Items == order.Items)
            return new ServiceResult<Order> { Errors = new List<string> { "You already placed such an order" } };
        
        var placedOrder = await _webShopDbContext.Orders.AddAsync(order);
        await _webShopDbContext.SaveChangesAsync();
        
        return new ServiceResult<Order> { Value = placedOrder.Entity };
    }

    public async Task<ServiceResult<Order>> GetOrderAsync(Order order)
    {
        var placedOrder = await _webShopDbContext.Orders.FirstOrDefaultAsync(x => x == order);
        return new ServiceResult<Order> { Value = placedOrder };
    }

    public Task<ServiceResult<Order>> CancelOrderAsync(Order order)
    {
        //add login area, do this if extending project (if ever)
        throw new NotImplementedException();
    }
}