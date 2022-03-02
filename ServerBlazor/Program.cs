using Blazored.Toast;
using HttpModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ServerBlazor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ICatalog>(InMemoryCatalog.MakeTestCatalog());
builder.Services.AddSingleton<ObservableShoppingCart>();
builder.Services.AddSingleton<IClock, Clock>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();