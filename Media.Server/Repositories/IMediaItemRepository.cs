using Medias.Data.Entities;
using Medias.Shared;
using System.Linq.Expressions;
namespace Medias.Server.Repositories
{
    public interface IMediaItemRepository
    {
        Task <IEnumerable<MediaItem>>GetMediaItems();
    }
}
