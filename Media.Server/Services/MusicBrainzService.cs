using Medias.Integrations.MusicBrainz;
using Medias.Server.DTOs;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using System.Text.Json;


namespace Medias.Server.Services
{
    public class MusicBrainzService : IMusicBrainzService
    {
        private readonly IConfiguration _configuration;
        private readonly IMusicBrainzClient _musicBrainzClient;
        //private readonly HttpClient _httpClient;

        public MusicBrainzService(IConfiguration configuration, IMusicBrainzClient musicBrainzClient)
        {
            _configuration = configuration;
            _musicBrainzClient = musicBrainzClient;
        }
        public async Task<IEnumerable<SearchResultDto>> SearchAlbumsAsync(string title)
        {
           var response = await _musicBrainzClient.SearchAlbumsAsync(title);
            var searchResults = response?.ReleaseGroups?.Select(album => new SearchResultDto
            {
                ImportId = album.Id.ToString(),
                Title = album.Title,
                MediaType = MediaTypeValue.Music,
                ReleaseDate = album.FirstReleaseDate,
                PosterPath = album.AlbumUrl,
                AdditionalInfo = JsonSerializer.Serialize(album)
            }).ToList();
            //return response;
            return searchResults;
        }

        

        public async Task<IEnumerable<SearchResultDto>> SearchSongsAsync(string title)
        {
            var response = await _musicBrainzClient.SearchSongsAsync(title);
            var searchResults = response?.Recordings?.Select(song => new SearchResultDto
            {
                ImportId = song.Id.ToString(),
                Title = song.Title,
                MediaType = MediaTypeValue.Music,
                ReleaseDate = song.FirstReleaseDate,
                PosterPath = string.Join(", ", song.ArtistCredits.Select(ac => ac.Name)),
                AdditionalInfo = JsonSerializer.Serialize(song)
            }).ToList();
            //return response;
            return searchResults;
        }
        
       public async Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id)
        {
           var response = await _musicBrainzClient.GetAlbumAndSongs(id);
           return response;
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
