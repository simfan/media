using Medias.Server.DTOs;
namespace Medias.Server.Services.Interfaces
{

    public interface ITMDbService
    {
        Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title);
        Task<TMDbMovieResult> GetMovieById(int id);
        Task<TMDbTVSearchResponse?> SearchTvShowsAsync(string title);
        Task<TMDbTVResult?> GetTVShowById(int id);
    }
}
