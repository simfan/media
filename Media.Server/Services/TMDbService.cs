using Medias.Server.DTOs;
using Medias.Server.Services.Interfaces;
using Medias.Server.Settings;
using Microsoft.Extensions.Options;

namespace Medias.Server.Services
{
    public class TMDbService : ITMDbService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly TMDbSettings _settings;

        public TMDbService(IConfiguration configuration, HttpClient httpClient, IOptions<TMDbSettings> options)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _settings.BearerToken);
        }

        public async Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title)
        {
            var response = await _httpClient.GetAsync($"search/movie?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TMDbMovieSearchResponse>();
        }

        public async Task<TMDbMovieResult?> GetMovieById(int id)
        {
            var response = await _httpClient.GetAsync($"movie/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TMDbMovieResult>();
        }

        
        public async Task<TMDbTVSearchResponse?> SearchTvShowsAsync(string title)
        {
            var response = await _httpClient.GetAsync($"search/tv?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode() ;
            return await response.Content.ReadFromJsonAsync<TMDbTVSearchResponse>();
        }

        public async Task<TMDbTVResult?> GetTVShowById(int id)
        {
            var response = await _httpClient.GetAsync($"tv/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TMDbTVResult>();
        }
    }
}
