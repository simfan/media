using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medias.Data;
using Medias.Data.Entities;
using Medias.Data.Configurations;
using Medias.Data.Contexts;
using Medias.Data.Conversions;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class MediaItemController : ControllerBase
    {
        private readonly MediaDbContext _context;

        public MediaItemController(MediaDbContext context)
        {
            _context = context;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MediaItemDto>>> GetMediaItems()
        {
            var mediaItems = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .ToListAsync();
            return mediaItems.Select(mi => mi.ToMediaItemDto()).ToList();
        }

        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .Include(mi => mi.MovieDetail)
                .Where(mi => mi.MediaType == MediaTypeValue.Movie)
                .ToListAsync();
            var movieDtos = new List<MovieDto>();
            foreach (var movie in movies)
            {
                var movieDto = MovieConversions.ToMovieDto(movie);
                movieDtos.Add(movieDto);
            }
            return movieDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MediaItemDtoFull>> GetMediaItemFull(int id)
        {
            var mediaItem = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .FirstOrDefaultAsync(mi => mi.Id == id);

            if (mediaItem == null)
            {
                return NotFound();
            }
            switch(mediaItem.MediaType)
            {
                case MediaTypeValue.Movie:
                    var movieDetails = await _context.MovieDetails
                        .FirstOrDefaultAsync(md => md.MediaItemId == id);
                    mediaItem.MovieDetail = movieDetails;
                    break;
                case MediaTypeValue.TV:
                    break;
            }
            return mediaItem.ToMediaItemDtoFull();
        }

        [HttpGet("{id}/other")]
        public async Task<ActionResult<MediaItemDto>> GetMediaItem(int id)
        {
            var mediaItem = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .FirstOrDefaultAsync(mi => mi.Id == id);

            if (mediaItem == null)
            {
                return NotFound();
            }
            switch (mediaItem.MediaType)
            {
                case MediaTypeValue.Movie:
                    var movieDetails = await _context.MovieDetails
                        .FirstOrDefaultAsync(md => md.MediaItemId == id);
                    mediaItem.MovieDetail = movieDetails;
                    break;
                case MediaTypeValue.TV:
                    break;
            }
            return mediaItem.ToMediaItemDto();
        }

        [HttpGet("/movie/{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .Include(mi => mi.MovieDetail)
                .FirstOrDefaultAsync(mi => mi.Id == id && mi.MediaType == MediaTypeValue.Movie);

            if (movie == null)
            {
                return NotFound();
            }

            return MovieConversions.ToMovieDto(movie);
        }

        [HttpPost()]
        public async Task<ActionResult<MediaItemDto>> CreateMediaItem(CreateMediaItemDto createDto)
        {
            var mediaItem = createDto.CreateDtoToMediaItem();
            _context.MediaItems.Add(mediaItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMediaItem), new { id = mediaItem.Id }, mediaItem.ToMediaItemDto());
        }

        [HttpPost("movie")]
        public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createDto)
        {
            var mediaItem = createDto.CreateDtoToMediaItem();
            _context.MediaItems.Add(mediaItem);
            
            await _context.SaveChangesAsync();
            var movieDetails = createDto.CreateDtoToMovieDetail(mediaItem.Id);
            _context.MovieDetails.Add(movieDetails);
            await _context.SaveChangesAsync();
            mediaItem.MovieDetail = movieDetails;

            return CreatedAtAction(nameof(GetMovie), new { id = mediaItem.Id }, MovieConversions.ToMovieDto(mediaItem));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMediaItem(int id, UpdateMediaItemDto updateDto)
        {
            if (id != updateDto.Id)
            {
                return BadRequest();
            }
            var existingMediaItem = await _context.MediaItems.FindAsync(id);
            if (existingMediaItem == null)
            {
                return NotFound();
            }
            updateDto.UpdateDtoToMediaItem(existingMediaItem);
            _context.Entry(existingMediaItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPut("{id}/movie")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateDto)
        {
            if (id != updateDto.Id)
            {
                return BadRequest();
            }
            var existingMediaItem = await _context.MediaItems.FindAsync(id);
            
            if (existingMediaItem == null)
            {
                return NotFound();
            }
            var existingMovieDetail = await _context.MovieDetails.FirstOrDefaultAsync(md => md.MediaItemId == id);

            updateDto.UpdateDtoToMediaItem(existingMediaItem);

            _context.Entry(existingMediaItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaItem(int id)
        {
            var mediaItem = await _context.MediaItems.FindAsync(id);
            if (mediaItem == null)
            {
                return NotFound();
            }
            _context.MediaItems.Remove(mediaItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool MediaItemExists(int id)
        {
            return _context.MediaItems.Any(e => e.Id == id);
        }
    }
}
