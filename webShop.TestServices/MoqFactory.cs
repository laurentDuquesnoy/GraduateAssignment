using Moq;
using NSubstitute;
using webShop.Abstractions;
using webShop.Services;

namespace webShop.TestServices;

public static class MoqFactory
{
    public static Mock<IDatabaseService> GenerateDatabaseService()
    {
        var itemsList = TestDataFactory.GenerateItemList();
        var orderList = TestDataFactory.GenerateOrderList();
        var customerList = TestDataFactory.GenerateCustomerList();
        
        var databaseService = new Mock<IDatabaseService>();
        
        databaseService.Setup(x => x.GetItemsAsync())
            .Returns(Task.FromResult(itemsList));
        databaseService.Setup(x => x.GetItemByIdAsync(It.IsAny<int>()))
            .Returns<int>(i => Task.FromResult(itemsList.FirstOrDefault(x => x.Id == i)));
        
        databaseService.Setup(x => x.GetOrdersAsync())
            .Returns(Task.FromResult(orderList));
        databaseService.Setup(x => x.GetOrderByIdAsync(It.IsAny<int>()))
            .Returns<int>(i => Task.FromResult(orderList.FirstOrDefault(x => x.Id == i)));

        databaseService.Setup(x => x.GetCustomersAsync())
            .Returns(Task.FromResult(customerList));
        databaseService.Setup(x => x.GetCustomerByIdAsync(It.IsAny<int>()))
            .Returns<int>(i => Task.FromResult(customerList.FirstOrDefault(x => x.Id == i)));


        return databaseService;
    }
    public static Mock<IItemService> GenerateItemService()
    {
        var itemsList = TestDataFactory.GenerateItemList();
        var itemService = new Mock<IItemService>();
        itemService.Setup(x => x.GetItemsAsync())
            .Returns(Task.FromResult(itemsList));

        itemService.Setup(x =>
                x.GetByIdAsync(It.IsAny<int>()))
            .Returns<int>(i => Task.FromResult(itemsList.First(x => x.Id == i)));

        return itemService;
    }
}