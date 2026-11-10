using Medias.Data.Entities;
using Medias.Shared;
using System.Linq.Expressions;
namespace Medias.Server.Repositories.Interfaces
{
    public interface IMediaItemRepository
    {
        Task<IEnumerable<MediaItem>> GetMediaItems();
        Task<MediaItem> GetMediaItemById(int id);
        Task<MediaItem> GetMediaItemByBarcode(string barcode);
        Task<MediaItem> AddMediaItem(MediaItem mediaItem);
        Task<bool> UpdateMediaItem(MediaItem mediaItem);
        Task<bool> DeleteMediaItem(int id);
        Task<IEnumerable<MediaItem>> GetMovies();
        Task<MediaItem> GetMovieById(int id);
        Task<MediaItem> GetMovieByTmdbId(int tmdbId);
        /*Task<IEnumerable<MediaItem>> GetTVShows();
        Task<MediaItem> GetTVShowById(int id);*/
    }
}
