using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;
using webShop.Model;
using webShop.Repository;

namespace webShop.Services;

public class DatabaseService : IDatabaseService
{
    private readonly WebShopDbContext _webShopDbContext;

    public DatabaseService(WebShopDbContext webShopDbContext)
    {
        _webShopDbContext = webShopDbContext;
    }

    public async Task<List<ShopItem>> GetItemsAsync()
        => await _webShopDbContext.ShopItems.ToListAsync();
    

    public async Task<ShopItem?> GetItemByIdAsync(int id)
        => await _webShopDbContext.ShopItems.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<ShopItem> CreateItemAsync(ShopItem item)
    {
        var newItem = await _webShopDbContext.ShopItems.AddAsync(item);
        return newItem.Entity;
    }


    public async Task<List<Order>> GetOrdersAsync() 
        => await _webShopDbContext.Orders.ToListAsync();


    public async Task<Order?> GetOrderByIdAsync(int id)
        => await _webShopDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Order> CreateOrderAsync(Order order)
    {
        var newItem = await _webShopDbContext.Orders.AddAsync(order);
        return newItem.Entity;    }


    public async Task<List<Customer>> GetCustomersAsync()
        => await _webShopDbContext.Customers.ToListAsync();


    public async Task<Customer?> GetCustomerByIdAsync(int id)
        => await _webShopDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        var newItem = await _webShopDbContext.Customers.AddAsync(customer);
        return newItem.Entity;
    }


    public async Task SaveChangesAsync()
    {
        await _webShopDbContext.SaveChangesAsync();
    }
}