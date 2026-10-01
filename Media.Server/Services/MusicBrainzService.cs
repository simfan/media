using Medias.Server.DTOs;
using Medias.Server.Services.Interfaces;

namespace Medias.Server.Services
{
    public class MusicBrainzService : IMusicBrainzService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MusicBrainzService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://musicbrainz.org/ws/2/");

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MediaManager/1.0 (cglock84@gmail.com)");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<MusicBrainzReleaseGroupResults> SearchAlbumsAsync(string title)
         {
           var response = await _httpClient.GetAsync($"release-group?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MusicBrainzReleaseGroupResults>();
        }

        

        public async Task<MusicBrainzRecordingSearchResult> SearchSongsAsync(string title)
        {
            var response = await _httpClient.GetAsync($"recording?query={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MusicBrainzRecordingSearchResult>();
            //return albumSearchResult;
        }
        
       public async Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id)
        {
           var response = await _httpClient.GetAsync($"release?{id}&inc=recordings");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MusicBrainzReleaseGroupSearchResult>();
        }
        /*
        public GetAlbumById(string id)
        {
            var response = await _httpClient.GetAsync($"release-group/{id}");
        }

        public GetSongById(string id)
            {
            var response = await _httpClient.GetAsync($"recording/{id}");
        }*/
    }
}
