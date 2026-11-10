

namespace Medias.Integrations.TMDb
{
    public interface ITMDbClient
    {
        Task<TMDbMovieSearchResponse?> SearchMoviesAsync(string title);
        Task<TMDbMovieResult?> GetMovieById(int id);
        //Task<ImportMovieResultsDto> ImportMovieData(int id);
        Task<TMDbTVSearchResponse?> SearchTvShowsAsync(string title);
        Task<TMDbTVResult?> GetTVShowById(int id);
    }
}
