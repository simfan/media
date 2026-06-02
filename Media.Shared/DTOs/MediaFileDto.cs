using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MediaFileDto
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
        public MediaItemDto MediaItem { get; set; }
    }

    public class  CreateMediaFileDto
    {
        public int MediaItemId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }//relative path to the file
        public long FileSize { get; set; }
        public string FileType { get; set; }//extension
        public string Checksum { get; set; }
    }

    public class UpdateMediaFileDto
    {
        public int Id { get; set; }
        public int MediaItemId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }//relative path to the file
        public long FileSize { get; set; }
        public string FileType { get; set; }//extension
        public string Checksum { get; set; }
    }
}
