using Microsoft.EntityFrameworkCore;
using Moq;
using webShop.Model;

namespace webShop.TestServices;

public static class OrderTestService
{
    public static List<Order> GenerateOrderList()
    {
        return new List<Order>
        {
            new()
            {
                Customer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@webshop.com",
                    Address = "privet drive, little surrey"
                },
                Items = ItemTestService.GenerateItemList(),
                TimeStamp = DateTime.MinValue
            },
            new()
            {
                Customer = new Customer
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@webshop.com",
                    Address = "privet drive, little surrey"
                },
                Items = ItemTestService.GenerateItemList(),
                TimeStamp = DateTime.MinValue
            },
            new()
            {
                Customer = new Customer
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Email = "harry.potter@student.hogwarts.com",
                    Address = "privet drive, little surrey (not for long)"
                },
                Items = ItemTestService.GenerateItemList(),
                TimeStamp = DateTime.MinValue
            },
        };
    }
}