using Nlayer.Core.Dtos;

namespace Nlayer.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpclient;

        public CategoryApiService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpclient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("categories");
            return response.Data;

        }
    }
}
