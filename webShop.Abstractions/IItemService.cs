using webShop.Model;

namespace webShop.Abstractions;

public interface IItemService
{
    Task<List<ShopItem>> GetItemsAsync();
    Task<ShopItem> GetByIdAsync(int id);
}