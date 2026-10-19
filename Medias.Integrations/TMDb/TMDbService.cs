using Medias.Integrations.TMDb;
using Medias.Shared.DTOs;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Medias.Integrations.TMDb
{
    /*public class TMDbService : ITMDbService
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
            if (!string.IsNullOrWhiteSpace(_settings.BearerToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.BearerToken);
            }
        }

        public async Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title)
        {
            var url = string.IsNullOrWhiteSpace(_settings.ApiKey)
                ? $"search/movie?query={Uri.EscapeDataString(title)}"
                : $"search/movie?query={Uri.EscapeDataString(title)}&api_key={_settings.ApiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TMDbMovieSearchResponse>();
        }

        public async Task<UpdateMovieDto?> GetMovieById(int id)
        {
            var response = await _httpClient.GetAsync($"movie/{id}");
            response.EnsureSuccessStatusCode();
            var tmdbMovie = await response.Content.ReadFromJsonAsync<TMDbMovieResult>();
            var movieDto = tmdbMovie.ToMovieDto();
            return movieDto;
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
    }*/
}
