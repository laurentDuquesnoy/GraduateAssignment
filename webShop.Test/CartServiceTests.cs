using System;
using webShop.Services;
using webShop.TestServices;
using Xunit;

namespace webShop.Test;

public class CartServiceTests
{
    [Fact]
    public void CheckThatCartServiceSurvivesRemovalOfNonexistentItem()
    {
        var cartService = new CartService();
        foreach (var item in TestDataFactory.GenerateItemList())
        {
            cartService.AddToCart(item);
        }
        
        cartService.RemoveFromCart(int.MaxValue);
        Assert.Equal(3, cartService.GetNumberOfItemsInCart());
    }
}