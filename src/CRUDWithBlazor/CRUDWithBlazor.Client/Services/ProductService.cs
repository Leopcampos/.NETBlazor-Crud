using SharedLibrary.Models;
using SharedLibrary.Repositories;
using System.Net.Http;
using System.Net.Http.Json;

namespace CRUDWithBlazor.Client.Services
{
    public class ProductService : IProductRepository
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product> AddProductAsync(Product model)
        {
            var product = await _httpClient.PostAsJsonAsync("api/Product/Add-Product", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = await _httpClient.PutAsJsonAsync("api/Product/Update-Product", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var product = await _httpClient.DeleteAsync($"api/Product/Delete-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _httpClient.GetAsync("api/Product/All-Products");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _httpClient.GetAsync($"api/Product/Single-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

    }
}