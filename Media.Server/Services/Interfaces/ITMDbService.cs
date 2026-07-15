using Medias.Server.DTOs;
using Medias.Shared.DTOs;
namespace Medias.Server.Services.Interfaces
{

    public interface ITMDbService
    {
        Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title);
        Task<UpdateMovieDto>GetMovieById(int id);
        Task<ImportMovieResultsDto> ImportMovieData(int id);
        Task<TMDbTVSearchResponse?> SearchTvShowsAsync(string title);
        Task<TMDbTVResult?> GetTVShowById(int id);
    }
}
