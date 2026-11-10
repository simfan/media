

namespace Medias.Integrations.OpenLibrary
{
    public interface IOpenLibraryClient
    {
        Task<OpenLibraryResults> SearchBooksAsync(string query, int page = 1);
        Task<OpenLibraryEdition?> GetBookByIdAsync(string id);
        Task<OpenLibraryEdition?> GetEditionByIdAsync(string id);
    }
}
 