using Medias.Data.Contexts;
using Medias.Data.Conversions;
using Medias.Data.Entities;
using Medias.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly MediaDbContext _context;

        public CollectionsController(MediaDbContext context)
        {
            _context = context;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetCollections()
        {
            var collections = await _context.Collections.ToListAsync();
            return collections.Select(c => c.ToCollectionDto()).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionDto>> GetCollection(int id)
        {
            var collection = await _context.Collections
                                            .Include(c => c.MediaItemCollections)
                                                .ThenInclude(mic => mic.MediaItem)
                                            .FirstOrDefaultAsync(c => c.CollectionId == id);
            if (collection == null)
            {
                return NotFound();
            }
            return collection.ToCollectionDto();
        }
        [HttpPost]
        public async Task<ActionResult<CollectionDto>> CreateCollection(CreateCollectionDto createDto)
        {
            var collection = createDto.CreateDtoToCollection();
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCollection), new { id = collection.CollectionId }, collection.ToCollectionDto());
        }

        [HttpPost("mediaCollection")]
        public async void AddMediaItemCollection(MediaItemCollectionDto mediaItemCollectionDto)
        {
            var mediaItemCollection = new MediaItemCollection()
            {
                CollectionId = mediaItemCollectionDto.CollectionId,
                MediaItemId = mediaItemCollectionDto.MediaItemId
            };

            _context.MediaItemCollections.Add(mediaItemCollection);
            await _context.SaveChangesAsync();

        }

        [HttpPost("mediaCollections")]
        public async void AddMediaItemCollecitions(List<MediaItemCollectionDto> mediaItemCollectionDtos)
        {
            List<MediaItemCollection> mediaItemCollections = new();
            foreach(var mediaItemCollectionDto in mediaItemCollectionDtos)
            {
                var mediaItemCollection = new MediaItemCollection()
                {
                    MediaItemId = mediaItemCollectionDto.MediaItemId,
                    CollectionId = mediaItemCollectionDto.CollectionId
                };
                mediaItemCollections.Add(mediaItemCollection);
            }
            _context.MediaItemCollections.AddRange(mediaItemCollections);
            await _context.SaveChangesAsync();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollection(int id, UpdateCollectionDto updateDto)
        {
            if (id != updateDto.CollectionId)
            {
                return BadRequest();
            }
            var existingCollection = await _context.Collections.FindAsync(id);
            if (existingCollection == null)
            {
                return NotFound();
            }
            updateDto.UpdateDtoToCollection(existingCollection);
            _context.Entry(existingCollection).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
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
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{collectionId}/mediaItem/{mediaItemId}")]
        public async Task<IActionResult> DeleteMediaItemCollection(int collectionId, int mediaItemId)
        {
            var mediaItemCollection = await _context.MediaItemCollections.FindAsync(mediaItemId, collectionId);
            if(mediaItemCollection == null)
            {
                return NotFound();
            }
            _context.MediaItemCollections.Remove(mediaItemCollection);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.CollectionId == id);
        }


    }
}
