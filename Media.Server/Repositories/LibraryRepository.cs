using Medias.Data.Contexts;
using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medias.Server.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly MediaDbContext _context;

        public LibraryRepository(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Library>> GetLibraries()
        {
            var libraries = await _context.Libraries.ToListAsync();
            return libraries;
        }

    }
}
