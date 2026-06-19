using Medias.Data;
using Medias.Data.Contexts;
using Medias.Data.Entities;
using Medias.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.WebSockets;

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
            var mediaItems = await _context.MediaItems
                .Include(mi =>mi.MediaFiles)
                .ToListAsync();
            return mediaItems;
        }

        public async Task<MediaItem> GetMediaItemById(int id)
        {
            var mediaItem = await _context.MediaItems.FindAsync(id);
            return mediaItem;
        }

        public async Task<MediaItem> AddMediaItem(MediaItem mediaItem)
        {
            await _context.MediaItems.AddAsync(mediaItem);
            _context.SaveChanges();
            return mediaItem;
        }

        /*public async Task<MovieDetail> AddMovieDetail(MovieDetail movieDetail)
        {
            await _context.MovieDetails.AddAsync(movieDetail);
            _context.SaveChanges();
            return movieDetail;
        }*/

        public async Task<TelevisionShowDetail> AddTelevisionShowDetail(TelevisionShowDetail televisionShowDetail)
        {
            await _context.TelevisionShowDetails.AddAsync(televisionShowDetail);
            _context.SaveChanges();
            return televisionShowDetail;
        }

        public async Task<bool> UpdateMediaItem(MediaItem mediaItem)
        {
            var existingItem = await _context.MediaItems.FindAsync(mediaItem.Id);
            if (existingItem is null)
            {
                throw new InvalidOperationException("Media Item not found");
            }
            _context.Entry(existingItem).CurrentValues.SetValues(mediaItem);
            await _context.SaveChangesAsync();
            return true;
        }

        /*public async Task<bool> UpdateMovieDetail(MovieDetail movieDetail)
        {
            var existingMovie = await _context.MovieDetails.FindAsync(movieDetail.MediaItemId);
            if (existingMovie is null)
            {
                throw new InvalidOperationException("Movie Detail not found");
            }
            _context.Entry(existingMovie).CurrentValues.SetValues(movieDetail);
            await _context.SaveChangesAsync();
            return true;
        }*/

        public async Task<bool> UpdateTelevisionShowDetaio(TelevisionShowDetail televisionShowDetail)
        {
            var existingShow = await _context.TelevisionShowDetails.FindAsync(televisionShowDetail.MediaItemId);
            if (existingShow is null)
            {
                throw new InvalidOperationException("Television Show Detail not found");
            }
            _context.Entry(existingShow).CurrentValues.SetValues(televisionShowDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMediaItem(int id)
        {
            var mediaItem = await _context.MediaItems.FindAsync(id);
            if(mediaItem == null)
            {
                return false;
            }
            _context.MediaItems.Remove(mediaItem);
            _context.SaveChanges();
            return true;
        }
        public async Task <IEnumerable<MediaItem>> GetMovies()
        {
            var movies = await _context.MediaItems
                .Include(m => m.MovieDetail)
                .Where(m => m.MediaType == MediaTypeValue.Movie)
                .ToListAsync();
            return movies;
        }

        public async Task<MediaItem> GetMovieById(int id)
        {
            var movie = await _context.MediaItems
                .Include(mi => mi.MovieDetail)
                .Include(mi => mi.MediaItemCollections)
                    .ThenInclude(mic => mic.Collection)
                .FirstOrDefaultAsync(mi => mi.Id == id);
            return movie;
        }

        public async Task<MediaItem> GetMovieByTmdbId(int tmdbId)
        {
            var movie = await _context.MediaItems
                .Include(mi => mi.MovieDetail)
                .Include(mi => mi.MediaItemCollections)
                    .ThenInclude(mic => mic.Collection)
                .FirstOrDefaultAsync(mi => mi.MovieDetail.TmdbMovieId == tmdbId);
            return movie;
        }
        public async Task<IEnumerable<MediaItem>> GetTVShows()
        {
            var shows = await _context.MediaItems
                .Include(m => m.TelevisionShowDetail)
                    .ThenInclude(tv => tv.Seasons)
                        .ThenInclude(s => s.Episodes)
                .Where(m => m.MediaType == MediaTypeValue.TV)
                .ToListAsync();
            return shows;
        }

        public async Task<MediaItem> GetTVShowById(int id)
        {
            var tvShow = await _context.MediaItems
                                .Include(mi => mi.TelevisionShowDetail)
                                    .ThenInclude(tv => tv.Seasons)
                                        .ThenInclude(s => s.Episodes)
                                .FirstOrDefaultAsync(mi => mi.Id == id);
            return tvShow;
        }
    }
}
