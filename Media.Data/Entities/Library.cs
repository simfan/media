using System;
using System.Collections.Generic;
using System.Text;
using Medias.Shared.Enums;

namespace Medias.Data.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }//root path of the library
        public LibraryTypeValue LibraryType { get; set; }//e.g. Movies, TV Shows, Music, etc.
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<MediaItem> MediaItems { get; set; } = new List<MediaItem>();
    }
}
