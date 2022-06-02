using webShop.Model;

namespace webShop.Abstractions;

public interface IDatabaseService
{
    public Task<List<ShopItem>> GetItemsAsync();
    public Task<ShopItem?> GetItemByIdAsync(int id);
    public Task<ShopItem> CreateItemAsync(ShopItem item);
    
    
    public Task<List<Order>> GetOrdersAsync();
    public Task<Order?> GetOrderByIdAsync(int id);
    public Task<Order> CreateOrderAsync(Order order);
    
    public Task<List<Customer>> GetCustomersAsync();
    public Task<Customer?> GetCustomerByIdAsync(int id);
    public Task<Customer> CreateCustomerAsync(Customer customer);
    

    public Task SaveChangesAsync();
}