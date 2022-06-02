using FakeItEasy;
using webShop.Abstractions;
using webShop.Model;
using webShop.Services;

namespace webShop.TestServices;

public class FakeItEasyFactory
{
    public static IItemService GenerateItemService()
    {
        var itemsList = TestDataFactory.GenerateItemList();
        var itemService = A.Fake<IItemService>();
        var item = A.Fake<ShopItem>();

        A.CallTo(() => itemService.GetItemsAsync()).Returns(itemsList);
        A.CallTo(() => itemService.GetByIdAsync(A<int>.Ignored) ).Returns(item);

        return itemService;
    }
    
}