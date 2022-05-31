namespace webShop.Model;

public class Order
{
    public int Id { get; set; }
    public Customer? Customer { get; set; }
    public List<ShopItem> Items { get; set; }
    public DateTime TimeStamp { get; set; }
}