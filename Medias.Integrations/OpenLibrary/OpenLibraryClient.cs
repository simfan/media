

namespace Medias.Integrations.OpenLibrary
{
    public class OpenLibraryClient: IOpenLibraryClient
    {
        //private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public OpenLibraryClient(HttpClient httpClient)
        {
            // _configuration = configuration;
            _httpClient = httpClient;
            
            _httpClient.BaseAddress = new Uri("https://openlibrary.org/");
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MediaManager/1.0 (cglock84@gmail.com)");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<OpenLibraryResults> SearchBooksAsync(string query, int page = 1)
        {
            var response = await _httpClient.GetAsync($"search.json?q={Uri.EscapeDataString(query)}&page={page}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = System.Text.Json.JsonSerializer.Deserialize<OpenLibraryResults>(content);
            return searchResult ?? new OpenLibraryResults();
        }

        public async Task<OpenLibraryEdition?> GetBookByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"books/{id}.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var book = System.Text.Json.JsonSerializer.Deserialize<OpenLibraryEdition>(content);
            return book;
        }

        public async Task<OpenLibraryEdition?> GetEditionByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"works/{id}.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var book = System.Text.Json.JsonSerializer.Deserialize<OpenLibraryEdition>(content);
            return book;
        }
    }
}
