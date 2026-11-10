//using Medias.Server.DTOs;
using Medias.Integrations.OpenLibrary;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using System.Text.Json;

namespace Medias.Server.Services
{
    public class OpenLibraryService: IOpenLibraryService
    {
        private readonly IConfiguration _configuration;
        private readonly IOpenLibraryClient _openLibraryClient;
        //private readonly HttpClient _httpClient;

        public OpenLibraryService(IConfiguration configuration, IOpenLibraryClient openLibraryClient)
        {
            _configuration = configuration;
            _openLibraryClient = openLibraryClient;
        }

        public async Task<IEnumerable<SearchResultDto>> SearchBooksAsync(string query, int page = 1)
        {
            var results = await _openLibraryClient.SearchBooksAsync(query, page);
            return results.Books.Select(book => new SearchResultDto
            {
                ImportId = book.WorkKey,
                Title = book.Title,
                ReleaseDate = book.PublishDate.ToString(),
                PosterPath = book.CoverImageUrl,
                AdditionalInfo = JsonSerializer.Serialize(book),
                MediaType = MediaTypeValue.Book
                //Author = book.Authors?.FirstOrDefault() ?? "Unknown Author",
            }).ToList();
        }
    }
}

