using System;
using System.Collections.Generic;
using System.Text;
using Medias.Shared.Enums;

namespace Medias.Data.Entities
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? LibraryId { get; set; }
        public string ThumbnailPath{ get; set; }
        public List<MediaFile>? MediaFiles { get; set; } 
        public Library? Library { get; set; }
        public MovieDetail? MovieDetail { get; set; }
        public TelevisionShowDetail? TelevisionShowDetail { get; set; }
        public MusicDetail? MusicDetail { get; set; }
        public List<MediaItemCollection> MediaItemCollections { get; set; } = new();
    }
}
