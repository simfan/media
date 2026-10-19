using Medias.Server.Services;
using Medias.Shared.DTOs;

namespace Medias.Client.Services
{
    public class MediaItemApiClient 
    {
        /*private readonly HttpClient _httpClient;

        public MediaItemApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MediaItemDto>> GetAllItemsAsync()
        {
            // This makes the actual network call to the server
            var response = await _httpClient.GetFromJsonAsync<List<MediaItemDto>>("api/mediaitem");
            return response;
        }

        public async Task<MediaItemDto> GetItemByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MediaItemDto>($"api/mediaitem/{id}");
        }*/
    }
}
