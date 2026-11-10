using Medias.Integrations.MusicBrainz;
using Medias.Server.Services;
using Medias.Server.DTOs;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicBrainzController : ControllerBase
    {
        private readonly IMusicBrainzService _musicBrainzService;
        private readonly IMediaItemService _mediaItemService;
        public MusicBrainzController (IMusicBrainzService musicBrainzService, IMediaItemService mediaItemService)
        {
            _musicBrainzService = musicBrainzService;
            _mediaItemService = mediaItemService;
        }
        [HttpGet("albums/search")]
        //public async Task<ActionResult<MusicBrainzReleaseGroupSearchResult>> SearchAlbums(string title)
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchAlbums(string title)
        {
            var results = await _musicBrainzService.SearchAlbumsAsync(title);
            return Ok(results);
        }

        [HttpGet("songs/search")]
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchSongs(string title)
        {
            var results = await _musicBrainzService.SearchSongsAsync(title);
            return Ok(results);
        }
        /*public async Task<ActionResult<MusicBrainzRecordingSearchResult>> SearchSongs(string title)
        {
            var results = await _musicBrainzService.SearchSongsAsync(title);
            return Ok(results);
        }*/

        [HttpGet("album/{id}")]
        public async Task<ActionResult<MusicBrainzReleaseGroupSearchResult>> GetAlbumById(string id)
        {
            var results = await _musicBrainzService.GetAlbumAndSongs(id);
            return Ok(results);
        }
    }
}
