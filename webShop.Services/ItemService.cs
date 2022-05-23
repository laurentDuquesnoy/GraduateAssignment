using System.Data;
using webShop.Model;
using webShop.Repository;
using Microsoft.EntityFrameworkCore;
using webShop.Abstractions;

namespace webShop.Services;

public class ItemService : IItemService
{
    private WebShopDbContext DbContext { get; set; }

    public ItemService(WebShopDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<List<ShopItem>> GetItemsAsync()
    {
        return await DbContext.ShopItems.ToListAsync();
    }

    public async Task<ShopItem> GetByIdAsync(int id)
    {
        var item = await DbContext.ShopItems.FirstOrDefaultAsync(x => x.Id == id);
        if (item != null)
            return item;
        throw new InvalidOperationException();
    }
}





