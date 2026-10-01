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
    public class LibrariesController : ControllerBase
    {

        private readonly MediaDbContext _context;
        private readonly ILibraryService _libraryService;

        public LibrariesController(MediaDbContext context, ILibraryService libraryService)
        {
            _context = context;
            _libraryService = libraryService;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LibraryDto>>> GetLibraries()
        {
            var libraries = await _context.Libraries.ToListAsync();
            return libraries.Select(l => l.ToLibraryDto()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> GetLibrary(int id)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == id);
            if (library == null)
            {
                return NotFound();
            }
            return library.ToLibraryDto();
        }

        [HttpPost]
        public async Task<ActionResult<LibraryDto>> CreateLibrary(CreateLibraryDto createLibraryDto)
        {
            var library = createLibraryDto.CreateDtoToLibrary();
            _context.Libraries.Add(library);
            await _context.SaveChangesAsync();
            return library.ToLibraryDto();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibrary(int id, UpdateLibraryDto updateLibraryDto)
        {
            if(id != updateLibraryDto.Id)
            {
                return BadRequest();
            }
            var existingLibrary= await _context.Libraries.FindAsync(id);
            if (existingLibrary == null) {
                return NotFound();
            }
            existingLibrary = updateLibraryDto.UpdateDtoToLibrary(existingLibrary);
            _context.Update(existingLibrary);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null) { return NotFound(); }
            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //Note: Move LibraryExists to service
        private bool LibraryExists(int id) {
            return _context.Libraries.Any(l => l.Id == id);
        }
    }
}
