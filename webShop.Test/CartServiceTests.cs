using System;
using webShop.Services;
using webShop.TestServices;
using Xunit;

namespace webShop.FakeItEasy;

public class CartServiceTests
{
    [Fact]
    public void CheckThatCartServiceSurvivesRemovalOfNonexistentItem()
    {
        var cartService = new CartService();
        foreach (var item in ItemTestService.GenerateItemList())
        {
            cartService.AddToCart(item);
        }
        
        cartService.RemoveFromCart(int.MaxValue);
        Assert.Equal(2, cartService.GetNumberOfItemsInCart());
    }
}