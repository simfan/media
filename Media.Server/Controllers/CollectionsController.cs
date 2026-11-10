using Medias.Data.Contexts;
using Medias.Data.Conversions;
using Medias.Data.Entities;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
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

        [HttpGet("albums")]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAlbums()
        {
            var collections = await _context.Collections.Include(c => c.Album).ToListAsync();
            List<AlbumDto> albumDtos = new();
            foreach (var collection in collections)
            {
                var albumDto = collection.ToAlbumDto();
                albumDtos.Add(albumDto);
            }
            return albumDtos;
        }

        [HttpGet("shows")]
        public async Task<ActionResult<IEnumerable<TelevisionShowDto>>> GetTelevisionShows()
        {
            var collections = await _context.Collections.Include(c => c.TelevisionShowDetail).ToListAsync();
            List<TelevisionShowDto> showDtos = new();
            foreach (var collection in collections)
            {
                if (collection.TelevisionShowDetail != null)
                {
                    var showDto = collection.ToTelevisionShowDto();
                    showDtos.Add(showDto);
                }
            }
            return showDtos;
        }

        [HttpGet("shows/{id}/seasons")]
        public async Task<ActionResult<IEnumerable<TelevisionSeasonDto>>> GetSeasons(int id)
        {
            var collections = await _context.Collections
                .Include(c => c.TelevisionSeason)
                .Where(c => c.TelevisionSeason != null && c.TelevisionSeason.TelevisionShowCollectionId == id)
                .ToListAsync();

            /*var seasons = await _context.TelevisionSeasons
                .Where(s => s.TelevisionShowDetail.CollectionId == id)
                .OrderBy(s => s.SeasonNumber)
                .ToListAsync();
            /*var seasons = await _context.Collections
                .Include(c => c.TelevisionSeason)  
                .Where(c => c.CollectionId == id)
                .SelectMany(c => c.TelevisionShowDetail.Seasons)
                .ToListAsync();*/
            var seasonsDTOs = collections.Select(c => c.ToTelevisionSeasonDto()).ToList();
            return seasonsDTOs;
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

        [HttpGet("albums/{id}")]
        public async Task<ActionResult<AlbumDto>> GetAlbum(int id)
        {
            var album = await _context.Collections
                .Include(c => c.Album)
                    .ThenInclude(a => a.Tracks)
                        .ThenInclude(t => t.MusicDetail)
                            .ThenInclude(md => md.MediaItem)
                .FirstOrDefaultAsync(c => c.CollectionId ==id);

            if(album == null)
            {
                return NotFound();
            }

            return album.ToAlbumDto();
            
        }

        [HttpGet("shows/{id}")]
        public async Task<ActionResult<TelevisionShowDto>> GetTVShow(int id)
        {
            var show = await _context.Collections
                /*.Include(c => c.TelevisionShowDetail)
                    .ThenInclude(ts => ts.Seasons)
                        .ThenInclude(s => s.TelevisionShowDetail)
                            .ThenInclude(md => md.MediaItem)
                .Include(c => c.TelevisionShowDetail)
                    .ThenInclude(ts => ts.Episodes)
                             .ThenInclude(md => md.MediaItem)*/
                .FirstOrDefaultAsync(c => c.CollectionId == id);

            if (show == null)
            {
                return NotFound();
            }

            return show.ToTelevisionShowDto();

        }

        [HttpPost]
        public async Task<ActionResult<CollectionDto>> CreateCollection(CreateCollectionDto createDto)
        {
            var collection = createDto.CreateDtoToCollection();
            //collection.CollectionType = CollectionTypeValue.Default;
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCollection), new { id = collection.CollectionId }, collection.ToCollectionDto());
        }
        /*[HttpPost("album")]
        public async Task<ActionResult<AlbumDto>> CreateAlbum(CreateAlbumDto createAlbumDto)
        {
            var collection = createAlbumDto.CreateDtoToCollection();
            collection.CollectionType = CollectionTypeValue.Album;
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            var album = createAlbumDto.CreateDtoToAlbum(collection.CollectionId);
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlbum), new { id = collection.CollectionId }, AlbumConversions.ToAlbumDto(album));
        }*/

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

        [HttpPost("albumTrack")]
        public async void AddAlbumTrack(TrackDto trackDto)
        {
            var albumTrack = new AlbumTrack()
            {
                CollectionId = trackDto.AlbumId,
                MediaItemId = trackDto.MusicId,
                TrackNumber = trackDto.TrackNumber,
                DiscNumber = trackDto.DiscNumber
            };
            _context.AlbumTracks.Add(albumTrack);
            await _context.SaveChangesAsync();
        }

        [HttpPost("show")]
        public async void AddTelevisionShow(CreateTelevisionShowDto createShowDto)
        {
            var collection = createShowDto.CreateDtoToCollection();
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            var show = createShowDto.CreateDtoToTelevisionShowDetail(collection.CollectionId);
            _context.TelevisionShowDetails.Add(show);
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
