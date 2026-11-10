//using Medias.Server.DTOs;
using Medias.Shared.DTOs;
namespace Medias.Server.Services.Interfaces
{

    public interface ITMDbService
    {
        Task<IEnumerable<SearchResultDto>> SearchMoviesAsync(string title);
        Task<UpdateMovieDto>GetMovieById(int id);
        Task<ImportMovieResultsDto> ImportMovieData(int id);
        Task<IEnumerable<SearchResultDto>> SearchTvShowsAsync(string title);
        Task<UpdateTelevisionShowDto?> GetTVShowById(int id);
    }
}
