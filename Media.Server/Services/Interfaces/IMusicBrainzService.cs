using Medias.Integrations.MusicBrainz;
using Medias.Shared.DTOs;
namespace Medias.Server.Services.Interfaces
{
    public interface IMusicBrainzService
    {
        //Task<MusicBrainzReleaseGroupResults> SearchAlbumsAsync(string title);
        Task<IEnumerable<SearchResultDto>> SearchAlbumsAsync(string title);
        //Task<MusicBrainzRecordingSearchResult> SearchSongsAsync(string title);
        Task<IEnumerable<SearchResultDto>> SearchSongsAsync(string title);
        Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id);
    }
}
