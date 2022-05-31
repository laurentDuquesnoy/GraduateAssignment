using webShop.Abstractions;
using webShop.Model;

namespace webShop.Services;

public class CartService : ICartService
{
    private List<ShopItem> ShopItems { get; set; }
    private PaymentMethod? PaymentMethod { get; set; }

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

    public void RemoveFromCart(int id)
    {
        var shopItem = ShopItems.FirstOrDefault(x => x.Id == id);
        
        if (shopItem != null && ShopItems.Contains(shopItem))
            ShopItems.Remove(shopItem);
    }

    public double GetCartTotal()
    {
        return ShopItems.Sum(x => x.Price);
    }

    public void SetPaymentMethod(PaymentMethod method)
    {
        PaymentMethod = method;
    }
    public PaymentMethod GetPaymentMethod()
    {
        return PaymentMethod ?? Model.PaymentMethod.MasterCard;
    }
}