using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class BookDetail
    { 
        public int MediaItemId { get; set; }
        public int Pages { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public string? Edition { get; set; }
        public string? BookFormat { get; set; }//HardCover, Paperback, Digital, Audio
        public int? TimeToRead { get; set; }
        public string? ISBN { get; set; }
        public string? OpenLibraryId { get; set; }
        public MediaItem MediaItem { get; set; }
    }
}
