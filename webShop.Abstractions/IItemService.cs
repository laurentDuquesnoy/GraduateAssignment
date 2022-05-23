using webShop.Model;

namespace webShop.Abstractions;

public interface IItemService
{
    Task<List<ShopItem>> GetItemsAsync();
}