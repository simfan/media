using Medias.Server.Services;
using Medias.Server.DTOs;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenLibraryController : ControllerBase
    {

        private readonly IOpenLibraryService _openLibraryService;
        private readonly IMediaItemService _mediaItemService;
        public OpenLibraryController(IOpenLibraryService openLibraryService, IMediaItemService mediaItemService)
        {
            _openLibraryService = openLibraryService;
            _mediaItemService = mediaItemService;
        }
        [HttpGet("search/books")]
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchBooks(string title)
        {
            var results = await _openLibraryService.SearchBooksAsync(title);
            return Ok(results);
        }

        /*[HttpGet("search/songs")]
        public async Task<ActionResult<MusicBrainzRecordingSearchResult>> SearchSongs(string title)
        {
            var results = await _musicBrainzService.SearchSongsAsync(title);
            return Ok(results);
        }

        [HttpGet("album/{id}")]
        public async Task<ActionResult<MusicBrainzReleaseGroupSearchResult>> GetAlbumById(string id)
        {
            var results = await _musicBrainzService.GetAlbumAndSongs(id);
            return Ok(results);
        }*/
    }
}
