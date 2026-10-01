using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class MusicDetail
    {
        public int MediaItemId { get; set; }
        public string Artist { get; set; }
        public string Writer { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public int Runtime { get; set; }
        public DateTime? FirstReleased{ get; set; }
        public decimal Rating { get; set; }
        public string? CoverArtPath { get; set; }
        public string? MusicBrainzRecordingId { get; set;  }
        public MediaItem MediaItem { get; set; }
        public List<AlbumTrack> AlbumTracks { get; set; } = new();
    }
}
