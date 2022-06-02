using System.Data;
using webShop.Model;
using webShop.Repository;
using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;

namespace webShop.Services;

public class ItemService : IItemService
{
    private readonly IDatabaseService _databaseService;
    public ItemService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<List<ShopItem>> GetItemsAsync()
    {
        return await _databaseService.GetItemsAsync();
    }

    public async Task<ShopItem> GetByIdAsync(int id)
    {
        var item = await _databaseService.GetItemByIdAsync(id);
        if (item != null)
            return item;
        throw new InvalidOperationException();
    }
}


