using Blazored.Toast;
using BlazorWebAssemblyClient;
using HttpModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ICatalog>(InMemoryCatalog.MakeTestCatalog());
builder.Services.AddSingleton<IShoppingCart, ShoppingCart>();
builder.Services.AddSingleton<IClock, Clock>();
//builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
