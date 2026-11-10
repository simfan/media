using Medias.Server.DTOs;
using Medias.Shared.DTOs;

namespace Medias.Server.Services.Interfaces
{
    public interface IOpenLibraryService
    {
        Task<IEnumerable<SearchResultDto>> SearchBooksAsync(string query, int page = 1);
    }
}
