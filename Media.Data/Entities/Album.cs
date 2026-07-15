using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class Album
    {
        public int CollectionId { get; set; }
        public string Artist { get; set; }
        public string Studio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string? CoverArtPath { get; set; }
        public string? MusicBrainzReleaseId { get; set; }
        public string? MusicBrainzReleaseGroupId { get; set; }
        //public int DiscCount { get; set; }
        //public int TrackCount => Tracks.Count;
        public List<AlbumTrack> Tracks { get; set; } = new();
        public Collection Collection { get; set; } = null!;
        //  public int? ParentCollectionId { get; set; }
    }
}
