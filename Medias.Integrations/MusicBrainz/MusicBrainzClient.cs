
namespace Medias.Integrations.MusicBrainz
{
    public class MusicBrainzClient : IMusicBrainzClient
    {
        //private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MusicBrainzClient(HttpClient httpClient)
        {
            //_configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://musicbrainz.org/ws/2/");

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MediaManager/1.0 (cglock84@gmail.com)");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<MusicBrainzReleaseGroupResults> SearchAlbumsAsync(string title)
        {
            var response = await _httpClient.GetAsync($"release-group?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = System.Text.Json.JsonSerializer.Deserialize<MusicBrainzReleaseGroupResults>(content);
            return searchResult ?? new MusicBrainzReleaseGroupResults();
        }

        public async Task<MusicBrainzRecordingSearchResult> SearchSongsAsync(string title)
        {
            var response = await _httpClient.GetAsync($"recording?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = System.Text.Json.JsonSerializer.Deserialize<MusicBrainzRecordingSearchResult>(content);
            return searchResult ?? new MusicBrainzRecordingSearchResult();
        }

       public async Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id)
       {
            var response = await _httpClient.GetAsync($"release?{id}&inc=recordings");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = System.Text.Json.JsonSerializer.Deserialize<MusicBrainzReleaseGroupSearchResult>(content);
            return searchResult ?? new MusicBrainzReleaseGroupSearchResult();
        }
    }
}
