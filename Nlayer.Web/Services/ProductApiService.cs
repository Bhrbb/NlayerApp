using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using System.Net.Http.Json;

namespace Nlayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpclient;

        public ProductApiService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<List<ProductWithCategory>> GetProductWithCategoriesAsync()
        {
            var response = await _httpclient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategory>>>("products/GetProductWithCategory");
            return response.Data;


        }
        public async Task<ProductDto> SaveAsync(ProductDto newproduct)
        {
            var response = await _httpclient.PostAsJsonAsync("products",newproduct);
            if (!response.IsSuccessStatusCode) return null;
           
            var responseBody= await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;


        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpclient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return response.Data;

        }

        public async Task<bool> UpdateAsync(int id)
        {
            var response = await _httpclient.PutAsJsonAsync($"products/{id}");
            return response.IsSuccessStatusCode;

        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpclient.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;

        }
    }
}
