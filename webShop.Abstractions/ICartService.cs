using webShop.Model;

namespace webShop.Abstractions;

public interface ICartService
{
    int GetNumberOfItemsInCart();
    void AddToCart(ShopItem item);
    IList<ShopItem> GetItems();
    void RemoveFromCart(int id);
    double GetCartTotal();
    void SetPaymentMethod(PaymentMethod method);
    void ClearCart();
    PaymentMethod GetPaymentMethod();
}