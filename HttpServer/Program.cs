using HttpModels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ICatalog catalog = InMemoryCatalog.MakeTestCatalog();

app.MapGet("/catalog", (HttpContext context) => catalog.GetProducts(context.Request.Headers.UserAgent.ToString()));
app.MapPost("/catalog/add_product", catalog.AddProduct);

app.Run();