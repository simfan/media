using Medias.Server.DTOs;
namespace Medias.Server.Services.Interfaces
{
    public interface IMusicBrainzService
    {
        Task<MusicBrainzReleaseGroupResults> SearchAlbumsAsync(string title);
        Task<MusicBrainzRecordingSearchResult> SearchSongsAsync(string title);
        Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id);
    }
}
