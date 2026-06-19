namespace Medias.Server.Services
{
    public class MusicBrainzService
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

        /*public SearchAlbumsAsync(string title)
         {
           var response = await _httpClient.GetAsync($"release-group?query={Uri.EscapeDataString(title)}"); 
         }

        public 

        public GetAlbumAndSongs(string id)
        {
           var response = await _httpClient.GetAsync($"release?{id}&inc=recordings");
        }
         */
    }
}
