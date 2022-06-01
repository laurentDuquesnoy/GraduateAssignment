using Moq;
using webShop.Abstractions;
using webShop.Services;

namespace webShop.TestServices;

public static class MoqMockFactory
{
    public static Mock<IItemService> GenerateItemService()
    {
        var itemsList = ItemTestService.GenerateItemList();
        var itemService = new Mock<IItemService>();
        itemService.Setup(x => x.GetItemsAsync())
            .Returns(Task.FromResult(itemsList));

        itemService.Setup(x =>
                x.GetByIdAsync(It.IsAny<int>()))
            .Returns<int>(i => Task.FromResult(itemsList.First(x => x.Id == i)));

        return itemService;
    }
}