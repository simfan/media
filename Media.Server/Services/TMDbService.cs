using Medias.Data.Conversions;
using Medias.Integrations.TMDb;
using Medias.Server.Conversions;
using Medias.Server.DTOs;
using Medias.Server.Repositories;
using Medias.Server.Repositories.Interfaces;
using Medias.Server.Services.Interfaces;
using Medias.Shared.Configurations;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Medias.Server.Services
{
    public class TMDbService : ITMDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediaItemRepository _mediaItemRepository;
        private readonly ITMDbClient _tmdbClient;

        public TMDbService(IConfiguration configuration, IMediaItemRepository mediaItemRepository, ITMDbClient tmdbClient)
        {
            _configuration = configuration;
            _mediaItemRepository = mediaItemRepository;
            _tmdbClient = tmdbClient;
        }

        public async Task<IEnumerable<SearchResultDto>> SearchMoviesAsync(string title)
        {

            var results = await _tmdbClient.SearchMoviesAsync(title);
            List<SearchResultDto>? searchResults = new();
            searchResults = results.Results.Select(result => new SearchResultDto
            {
                MediaType = MediaTypeValue.Movie,
                ImportId = result.ID.ToString(),
                Title = result.Title,
                Description = result.Overview,
                ReleaseDate = $"{result.Release_Date:MM-dd-yyyy}",
                PosterPath = $"https://image.tmdb.org/t/p/w500{result.Poster_Path}",
                AdditionalInfo = JsonSerializer.Serialize(result)
            }).ToList();
            return searchResults;
        }

        public async Task<UpdateMovieDto?> GetMovieById(int id)
        {
            var tmdbMovie = await _tmdbClient.GetMovieById(id);
            UpdateMovieDto movieDto = tmdbMovie.ToMovieDto();
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
        
        public async Task<IEnumerable<SearchResultDto>> SearchTvShowsAsync(string title)
        {
            var response = await _tmdbClient.SearchTvShowsAsync(title);
            List<SearchResultDto> searchResults = new();
            searchResults = response.Results.Select(result => new SearchResultDto
            {
                MediaType = MediaTypeValue.TV,
                ImportId = result.ID.ToString(),
                Title = result.Name,
                Description = result.Overview,
                ReleaseDate = (DateTime.TryParse(result.First_Air_Date, out var start) ? start.ToString("yyyy") : result.First_Air_Date),                PosterPath = $"https://image.tmdb.org/t/p/w500{result.Poster_Path}",
                AdditionalInfo = JsonSerializer.Serialize(result)
            }).ToList();
            return searchResults;
        }

        public async Task<UpdateTelevisionShowDto?> GetTVShowById(int id)
        {
            var response = await _tmdbClient.GetTVShowById(id);
            UpdateTelevisionShowDto show = new UpdateTelevisionShowDto
            {
                CollectionId = 0,
                Name = response.Name,
                Description = response.Overview,
                CreatedDate = DateTime.Now,
                TmdbTvId = response.ID,
                SeasonCount = response.Number_of_Seasons,
            };
            return show;
        }
    }
}
