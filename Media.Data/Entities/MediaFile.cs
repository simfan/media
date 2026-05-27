using System;
using System.Collections.Generic;
using System.Text;
namespace Media.Data.Entities
{
    public class MediaFile
    {
        public int Id { get; set; }
        public int MediaItemId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }//relative path to the file
        public long FileSize { get; set; }
        public string FileType { get; set; }//extension
        public string Checksum { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public MediaItem MediaItem { get; set; }
    }
}
