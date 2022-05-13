using webShop.Model;
using webShop.Repository;
using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;

namespace webShop.Services;

public class ItemService : IItemService
{
    private WebShopDbContext _dbContext { get; set; }

    public ItemService(WebShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ShopItem>> GetItemsAsync()
    {
        var itemsList = await _dbContext.ShopItems.ToListAsync();
        return itemsList;
    }
}