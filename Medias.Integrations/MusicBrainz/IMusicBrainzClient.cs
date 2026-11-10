

namespace Medias.Integrations.MusicBrainz
{
    public interface IMusicBrainzClient
    {
        Task<MusicBrainzReleaseGroupResults> SearchAlbumsAsync(string title);
        Task<MusicBrainzRecordingSearchResult> SearchSongsAsync(string title);
        Task<MusicBrainzReleaseGroupSearchResult> GetAlbumAndSongs(string id);
    }
}
