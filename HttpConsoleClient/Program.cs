using HttpClientAPI;
using HttpModels;

var host = "https://localhost:7117";
Console.WriteLine($"Host: {host}\n");

ShopClient shopClient = new ShopClient(host);

ShowProdycts(await shopClient.GetProducts());
await shopClient.AddProduct(new("Test", new("Тест"), 100m, 10));
ShowProdycts(await shopClient.GetProducts());

void ShowProdycts(IReadOnlyCollection<Product>? products)
{
    if (products is null)
        return;
    Console.WriteLine($"{"Название",-15}{"Цена",10}{"Количество",20}");
    foreach (var product in products)
        Console.WriteLine($"{product.Name,-15}{product.Price,10}{product.Quantity,20}");
    Console.WriteLine();
}