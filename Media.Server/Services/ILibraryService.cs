using Medias.Shared.DTOs;

namespace Medias.Server.Services
{
    public interface ILibraryService
    {
        Task<IEnumerable<LibraryDto>> GetLibrariesAsync();
    }
}
