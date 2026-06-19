using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medias.Data;
using Medias.Data.Entities;
using Medias.Data.Configurations;
using Medias.Data.Contexts;
using Medias.Data.Conversions;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using Medias.Server.Services;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class MediaItemController : ControllerBase
    {
        private readonly MediaDbContext _context;
        private readonly IMediaItemService _mediaItemService;

        public MediaItemController(MediaDbContext context, IMediaItemService mediaItemService)
        {
            _context = context;
            _mediaItemService = mediaItemService;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MediaItemDto>>> GetMediaItems()
        {
            var mediaItems = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .ToListAsync();
            //var mediaItems2 = _mediaItemService.GetMediaItemsAsync();
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
                    var tvDetails = await _context.TelevisionShowDetails
                        .Include(tv => tv.Seasons)
                        .ThenInclude(s => s.Episodes)
                        .FirstOrDefaultAsync(tv => tv.MediaItemId == id);
                        mediaItem.TelevisionShowDetail = tvDetails;    
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

        [HttpGet("/tv/{id}")]
        public async Task<ActionResult<TelevisionShowDto>> GetTV(int id) {
            var tv = await _context.MediaItems
                   .Include(mi => mi.MediaFiles)
                   .Include(mi => mi.TelevisionShowDetail)
                        .ThenInclude(tv => tv.Seasons)
                        .ThenInclude(ts => ts.Episodes)
                   .FirstOrDefaultAsync(mi => mi.Id == id && mi.MediaType == MediaTypeValue.TV);
            if(tv == null)
            {  
                return NotFound(); 
            }
            return TelevisionConversions.ToTelevisionShowDto(tv);
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            var movieDetails = createDto.CreateDtoToMovieDetail(mediaItem.Id);
            _context.MovieDetails.Add(movieDetails);
            await _context.SaveChangesAsync();
            mediaItem.MovieDetail = movieDetails;

            return CreatedAtAction(nameof(GetMovie), new { id = mediaItem.Id }, MovieConversions.ToMovieDto(mediaItem));
        }

        [HttpPost("tv")]
        public async Task<ActionResult<TelevisionSeasonDto>> CreateTVShow(CreateTelevisionShowDto createDto)
        {
            var mediaItem = createDto.CreateDtoToMediaItem();
            _context.MediaItems.Add(mediaItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                throw;
            }
            var showDetails = createDto.CreateDtoToTelevisionShowDetail(mediaItem.Id);
            _context.TelevisionShowDetails.Add(showDetails);
            await _context.SaveChangesAsync();
            mediaItem.TelevisionShowDetail = showDetails;

            return CreatedAtAction(nameof(GetTV), new { id = mediaItem.Id }, TelevisionConversions.ToTelevisionShowDto(mediaItem));
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
            var updatedMovieDetail = MovieConversions.UpdateDtoToMovieDetail(updateDto, existingMovieDetail);
            _context.Entry(updatedMovieDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        [HttpPut("{id}/tv")]
        public async Task<IActionResult> UpdateShow(int id, UpdateTelevisionShowDto updateDto)
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
            var existingTelevisionShowDetail = await _context.TelevisionShowDetails.FirstOrDefaultAsync(md => md.MediaItemId == id);
            
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
            var updatedTelevisionShowDetail = TelevisionConversions.UpdateDtoToTelevisionShowDetail(updateDto, existingTelevisionShowDetail);
            _context.Entry(updatedTelevisionShowDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVShowExists(id))
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

        private bool MovieExists(int id)
        {
            return _context.MovieDetails.Any(e => e.MediaItemId == id);
        }

        private bool TVShowExists(int id)
        {
            return _context.TelevisionShowDetails.Any(e => e.MediaItemId == id);
        }
    }
}
