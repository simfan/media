using Medias.Data.Conversions;
using Medias.Server.Conversions;
using Medias.Server.DTOs;
using Medias.Server.Repositories;
using Medias.Server.Services.Interfaces;
using Medias.Server.Settings;
using Medias.Shared.DTOs;
using Microsoft.Extensions.Options;

namespace Medias.Server.Services
{
    public class TMDbService : ITMDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediaItemRepository _mediaItemRepository;
        private readonly HttpClient _httpClient;
        private readonly TMDbSettings _settings;

        public TMDbService(IConfiguration configuration, IMediaItemRepository mediaItemRepository, HttpClient httpClient, IOptions<TMDbSettings> options)
        {
            _configuration = configuration;
            _mediaItemRepository = mediaItemRepository;
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _settings.BearerToken);
        }

        public async Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title)
        {
            //convert the response to a list of search results - make sure media type is set to movie
            var response = await _httpClient.GetAsync($"search/movie?query={Uri.EscapeDataString(title)}");
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

        public async Task<ImportMovieResultsDto> ImportMovieData(int id)
        {
            ImportMovieResultsDto importMovie = new();
            importMovie.TMDbMovie = await GetMovieById(id);
            var localMovie = await _mediaItemRepository.GetMovieByTmdbId(id);
            if(localMovie == null)
            {
                importMovie.ExistsInLibrary = false;
            }
            else
            {
                importMovie.ExisitingMovie = (MovieConversions.ToMovieDto(localMovie)).ToUpdateMovie();
                importMovie.ExistsInLibrary = true;
            }
            return importMovie;
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
