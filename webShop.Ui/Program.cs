using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using webShop.Repository;
using Microsoft.EntityFrameworkCore;
using webShop.Ui;
using webShop.Services;
using webShop.Abstractions;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<WebShopDbContext>(options => 
{
    options.UseInMemoryDatabase("webShopDb");
});

builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddTransient<IOrderService, OrderService>();

await builder.Build().RunAsync();
