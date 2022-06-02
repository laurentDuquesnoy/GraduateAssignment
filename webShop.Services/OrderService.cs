using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;
using webShop.Model;
using webShop.Repository;

namespace webShop.Services;

public class OrderService : IOrderService
{
    private readonly IDatabaseService _databaseService;

    public OrderService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<ServiceResult<Order>> PlaceOrderAsync(Order order)
    {
        var orders = await _databaseService.GetOrdersAsync();
        var lastOrderByUser = orders.Where(x => x.Customer?.Id == order.Customer?.Id).MaxBy(x => x.TimeStamp);
        if (lastOrderByUser?.TimeStamp - order?.TimeStamp <= TimeSpan.FromMinutes(5) &&
            lastOrderByUser?.Items.Count == order?.Items.Count)
            return new ServiceResult<Order> { Errors = new List<string> { "You already placed such an order" } };

        var placedOrder = await _databaseService.CreateOrderAsync(order);
        await _databaseService.SaveChangesAsync();

        return new ServiceResult<Order> { Value = placedOrder };
    }

    public async Task<ServiceResult<Order>> GetOrderByIdAsync(int id)
    {
        var placedOrder = await _databaseService.GetOrderByIdAsync(id);
        return new ServiceResult<Order> { Value = placedOrder };
    }


    public Task<ServiceResult<Order>> CancelOrderAsync(Order order)
    {
        //add login area, do this if extending project (if ever)
        throw new NotImplementedException();
    }
}