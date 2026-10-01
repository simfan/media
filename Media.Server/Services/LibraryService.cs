using Medias.Data.Conversions;
using Medias.Shared.DTOs;
using Medias.Server.Repositories;

namespace Medias.Server.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IConfiguration _configuration;
        private readonly ILibraryRepository _libraryRepository;
        public LibraryService(IConfiguration configuration, ILibraryRepository libraryRepository)
        {
            _configuration = configuration;
            _libraryRepository = libraryRepository;
        }
        public async Task<IEnumerable<LibraryDto>> GetLibrariesAsync()
        {
            var libraries = await _libraryRepository.GetLibraries();
            List<LibraryDto> libraryDtos = new List<LibraryDto>();
            foreach (var library in libraries)
            {
                var libraryDto = library.ToLibraryDto();
                libraryDtos.Add(libraryDto);
            }
            return libraryDtos;
        }
    }
}
