using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class AlbumTrack
    {
        public int TrackId { get; set; }
        public int CollectionId { get; set; }
        public int MediaItemId { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public Album Album { get; set; }
        public MusicDetail MusicDetail { get; set; }

    }
}
