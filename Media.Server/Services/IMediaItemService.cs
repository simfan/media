using Medias.Data.Entities;
using Medias.Shared;
using Medias.Shared.DTOs;

namespace Medias.Server.Services
{
    public interface IMediaItemService
    {
        Task<IEnumerable<MediaItemDtoFull>> GetMediaItemsAsync();
        Task<MovieDto> GetMovieById(int id);
        Task<MovieDto> GetMovieByTmdbId(int tmdbId);
    }
}
