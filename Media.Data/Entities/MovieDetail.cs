using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class MovieDetail
    {
        
        public int MediaItemId { get; set; }
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public MediaItem MediaItem { get; set; }
    }
}
