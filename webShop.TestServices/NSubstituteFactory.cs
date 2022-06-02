using NSubstitute;
using webShop.Abstractions;

namespace webShop.TestServices;

public static class NSubstituteFactory
{
    public static IItemService GenerateItemService()
    {
        var itemsList = TestDataFactory.GenerateItemList();
        var itemService = Substitute.For<IItemService>();

        itemService.GetItemsAsync().Returns(itemsList);
        itemService.GetByIdAsync(Arg.Any<int>())
            .Returns(i => itemsList.First());

        return itemService;
    }
}