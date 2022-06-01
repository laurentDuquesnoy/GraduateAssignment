using webShop.Model;

namespace webShop.TestServices;

public static class ItemTestService
{
    public static List<ShopItem> GenerateShopList()
    {
        return new List<ShopItem>
        {
            new()
            {
                Name = "IPhone 13",
                Description = "All-round Apple flagship device backing ground-breaking technology",
                Price = 800,
                ImagePath = "Assets/iphone_13.png"
            },
            new()
            {
                Name = "Oneplus 10 Pro",
                Description = "Oneplus's latest bombshell flagship",
                Price = 1000,
                ImagePath = "Assets/oneplus_10pro.png"
            }
        };
    }
}