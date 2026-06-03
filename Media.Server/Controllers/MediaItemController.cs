using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medias.Data;
using Medias.Data.Entities;
using Medias.Data.Configurations;
using Medias.Data.Contexts;
using Medias.Data.Conversions;
using Medias.Shared.DTOs;

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


        [HttpGet("{id}")]
        public async Task<ActionResult<MediaItemDto>> GetMediaItem(int id)
        {
            var mediaItem = await _context.MediaItems
                .Include(mi => mi.MediaFiles)
                .FirstOrDefaultAsync(mi => mi.Id == id);

            if (mediaItem == null)
            {
                return NotFound();
            }

            return mediaItem.ToMediaItemDto();
        }

        [HttpPost()]
        public async Task<ActionResult<MediaItemDto>> CreateMediaItem(CreateMediaItemDto createDto)
        {
            var mediaItem = createDto.CreateDtoToMediaItem();
            _context.MediaItems.Add(mediaItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMediaItem), new { id = mediaItem.Id }, mediaItem.ToMediaItemDto());
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
