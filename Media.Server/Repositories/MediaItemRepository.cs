using Medias.Data;
using Medias.Data.Contexts;
using Medias.Data.Entities;
using Medias.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Medias.Server.Repositories
{
    public class MediaItemRepository: IMediaItemRepository
    {
        private readonly MediaDbContext _context;

        public MediaItemRepository(MediaDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<MediaItem>> GetMediaItems()
        {
            var mediaItems = await _context.MediaItems.ToListAsync();
            return mediaItems;
        }

        public async Task <IEnumerable<MediaItem>> GetMovies()
        {
            var movies = await _context.MediaItems
                .Include(m => m.MovieDetail)
                .Where(m => m.MediaType == MediaTypeValue.Movie)
                .ToListAsync();
            return movies;
        }

        /*public async Task<IEnumerable<MediaItem>> GetTVShows()
        {
            var shows = await _context.MediaItems
                .Include(m => m.TelevisionShowDetail)
                    .ThenInclude(tv => tv.Seasons)
                        .ThenInclude(s => s.Episdoes)
                .Where(m => m.MediaType == MediaTypeValue.TV)
                .ToListAsync();
            return shows;
        }*/
    }
}
