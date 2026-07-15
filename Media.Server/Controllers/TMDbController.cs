using Medias.Server.Conversions;
using Medias.Server.Services;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDbController : ControllerBase
    {
        private readonly ITMDbService _tmdbService;
        private readonly IMediaItemService _mediaItemService;

        public TMDbController(ITMDbService tmdbService, IMediaItemService mediaItemService)
        {
            _tmdbService = tmdbService;
            _mediaItemService = mediaItemService;
        }
        [HttpGet("movie/search")]
        public async Task<ActionResult<IEnumerable<TMDbMovieSearchRecord>>> SearchMovie(string title)
        {
            var results = await _tmdbService.SearchMoviesAsync(title);
            List<TMDbMovieSearchRecord>? searchResults = new();
            foreach (var result in results.Results) {
                var searchResult = new TMDbMovieSearchRecord()
                {
                    ID = result.ID,
                    Title = result.Title,
                    Overview = result.Overview,
                    Release_Date = result.Overview,
                    Poster_Path = result.Poster_Path
                };
                searchResults.Add(searchResult);
            }
            return Ok(searchResults);
        }

        [HttpGet("movie/{id}")]
        public async Task<ActionResult<UpdateMovieDto>> GetMovieByTMDbId(int id) 
        {
            UpdateMovieDto movieDto =  (await _mediaItemService.GetMovieByTmdbId(id)).ToUpdateMovie();
            if (movieDto == null)
            {
                movieDto = await _tmdbService.GetMovieById(id);
            }
            return movieDto;
             
        }
        [HttpGet("movie/{id}/online")]
        public async Task<ActionResult<UpdateMovieDto>> GetMovieByTMDbIdOnline(int id)
        {
            var movieDto = await _tmdbService.GetMovieById(id);
            return movieDto;
         
        }

        [HttpGet("movie/{id}/import")]
        public async Task<ActionResult<ImportMovieResultsDto>> ImportMovieData(int id)
        {
            var importMovieDto = await _tmdbService.ImportMovieData(id);
            return importMovieDto;
        }

        [HttpGet("tv/search")]
        public async Task<ActionResult<IEnumerable<TMDbTVSearchRecord>>> SearchTV(string name)
        {
            var results = await _tmdbService.SearchTvShowsAsync(name);
            List<TMDbTVSearchRecord>? searchResults = new();
            foreach(var result in results.Results)
            {
                var searchResult = new TMDbTVSearchRecord()
                {
                    ID = result.ID,
                    Name = result.Name,
                    Overview = result.Overview,
                    First_Air_Date = result.First_Air_Date,
                    Last_Air_Date = result.Last_Air_Date,
                    Poster_Path = result.Poster_Path,
                    Number_of_Seasons = result.Number_of_Seasons,
                    Number_of_Episodes = result.Number_of_Episodes,
                };
                searchResults.Add(searchResult);
            }
            return Ok(searchResults);
        }
    }
}
