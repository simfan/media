using System;
using System.Collections.Generic;
using System.Text;

namespace Media.Data
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string MediaType { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime UpdatedDate { get; set; }
        public int LibraryId { get; set; }
        public string ThumbnailPath{ get; set; }
    }
}
