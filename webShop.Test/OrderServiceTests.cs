using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using webShop.Model;
using webShop.Repository;
using webShop.Services;
using webShop.TestServices;
using Xunit;

namespace webShop.Test;

public class OrderServiceTests
{
    [Fact]
    public async void TestDoubleOrderChecker()
    {
        var itemList = TestDataFactory.GenerateItemList();
        var customerList = TestDataFactory.GenerateCustomerList();
        var orderService = new OrderService(MoqFactory.GenerateDatabaseService().Object);

        var duplicateOrder = new Order
        {
            Items = itemList,
            Customer = customerList.First(),
            TimeStamp = DateTime.UnixEpoch
        };

        var uniqueOrder = new Order
        {
            Items = new List<ShopItem> { new() { Name = "Some egg i stole from Hagrid" } },
            Customer = customerList.First(),
            TimeStamp = DateTime.UnixEpoch
        };

        var duplicateResult = await orderService.PlaceOrderAsync(duplicateOrder);
        var uniqueResult = await orderService.PlaceOrderAsync(uniqueOrder);

        Assert.False(duplicateResult.IsSuccess);
        Assert.True(uniqueResult.IsSuccess);
    }
}