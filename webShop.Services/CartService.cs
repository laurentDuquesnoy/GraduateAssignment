using webShop.Abstractions;
using webShop.Model;

namespace webShop.Services;

public class CartService : ICartService
{
    private List<ShopItem> ShopItems { get; set; }

    public CartService()
    {
        ShopItems = new List<ShopItem>();
    }

    public int GetNumberOfItemsInCart() => ShopItems.Count;

    public void AddToCart(ShopItem item) => ShopItems.Add(item);


    public IList<ShopItem> GetItems()
    {
        return ShopItems;
    }
}