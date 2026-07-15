using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class AlbumDto : CollectionDto
    {
        public string Artist { get; set; }
        public string Studio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string CoverArtPath { get; set; } 
        public string MusicBrainzReleaseId { get; set; }
        public string MusicBrainzReleaseGroupId { get; set; }
        public int TrackCount { get; set; }
        public List<TrackDto> Tracks{ get; set; }
    }

    public class CreateAlbumDto : CreateCollectionDto
    {
        public string Artist { get; set; }
        public string Studio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string CoverArtPath { get; set; }
        public string MusicBrainzReleaseId { get; set; }
        public string MusicBrainzReleaseGroupId { get; set; }
    }

    public class UpdateAlbumDto : UpdateCollectionDto
    {
        public string Artist { get; set; }
        public string Studio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string CoverArtPath { get; set; }
        public string MusicBrainzReleaseId { get; set; }
        public string MusicBrainzReleaseGroupId { get; set; }
        public List<TrackDto> Tracks { get; set; }


    }

    public class TrackDto
    {
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public int AlbumId { get; set; }
        public int MusicId { get; set; }
        public MusicDto Music { get; set; }
    }

    public class CreateTrackDto
    {
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public int AlbumId { get; set; }
        public int MusicId { get; set; }
    }

    public class UpdateTrackDto
    {
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
    }
}
