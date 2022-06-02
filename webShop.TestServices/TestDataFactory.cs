using webShop.Model;

namespace webShop.TestServices;

public static class TestDataFactory
{
    public static List<ShopItem> GenerateItemList()
    {
        return new List<ShopItem>
        {
            new()
            {
                Id = 1,
                Name = "IPhone 13",
                Description = "All-round Apple flagship device backing ground-breaking technology",
                Price = 800,
                ImagePath = "Assets/iphone_13.png"
            },
            new()
            {
                Id = 2,
                Name = "Oneplus 10 Pro",
                Description = "Oneplus's latest bombshell flagship",
                Price = 1000,
                ImagePath = "Assets/oneplus_10pro.png"
            },
            new()
            {
                Id = 3,
                Name = "Samsung Galaxy S22 Ultra",
                Description = "Latest installment in the S Ultra generation offering up to 16GB of RAM memory",
                Price = 1200,
                ImagePath = "Assets/samsung_galaxy_s22Ultra.webp"
            }
        };
    }

    public static List<Customer> GenerateCustomerList()
    {
        return new List<Customer>
        {
            new()
            {
                Id = 1,
                FirstName = "Vernon",
                LastName = "Dursley",
                Email = "vernon@muggleNet.co.uk",
                Address = "4 Privet Drive, Little Whinging"
            },
            new()
            {
                Id = 2,
                FirstName = "Petunia ",
                LastName = "Evans Dursley",
                Email = "petunia@muggleNet.co.uk",
                Address = "4 Privet Drive, Little Whinging"
            },
            new()
            {
                Id = 3,
                FirstName = "Dudley",
                LastName = "Dursley",
                Email = "dudley@muggleNet.co.uk",
                Address = "4 Privet Drive, Little Whinging"
            }
        };
    }

    public static List<Order> GenerateOrderList()
    {
        var customers = GenerateCustomerList();
        var items = GenerateItemList();

        return new List<Order>
        {
            new()
            {
                Id = 1,
                Customer = customers[0],
                Items = items,
                TimeStamp = DateTime.UnixEpoch
            },new()
            {
                Id = 2,
                Customer = customers[1],
                Items = items,
                TimeStamp = DateTime.UnixEpoch
            },
            new()
            {
                Id = 3,
                Customer = customers[2],
                Items = items,
                TimeStamp = DateTime.UnixEpoch
            },
        };
    }
}