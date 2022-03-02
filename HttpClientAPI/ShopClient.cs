using HttpModels;
using System.Net.Http.Json;

namespace HttpClientAPI
{
    public class ShopClient
    {
        private readonly string _host;
        private readonly HttpClient _httpClient;

        public ShopClient(string? host = null, HttpClient? httpClient = null)
        {
            _host = host ?? "https://localhost:7117";
            _httpClient = httpClient ?? new();
        }

        public Task<IReadOnlyCollection<Product>?> GetProducts() =>
            _httpClient.GetFromJsonAsync<IReadOnlyCollection<Product>>($"{_host}/catalog");

        public Task AddProduct(Product product) =>
            _httpClient.PostAsJsonAsync($"{_host}/catalog/add_product", product);
    }
}