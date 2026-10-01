using Medias.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }//root path of the library
        public LibraryTypeValue LibraryType { get; set; }//e.g. Movies, TV Shows, Music, etc.
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<MediaItemDto> MediaItems { get; set; } = new List<MediaItemDto>();
    }

    public class CreateLibraryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }//root path of the library
        public LibraryTypeValue LibraryType { get; set; }//e.g. Movies, TV Shows, Music, etc.
        public List<CreateMediaItemDto> MediaItems { get; set; } = new List<CreateMediaItemDto>();
    }

    public class UpdateLibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }//root path of the library
        public LibraryTypeValue LibraryType { get; set; }//e.g. Movies, TV Shows, Music, etc.
        public List<UpdateMediaItemDto> MediaItems { get; set; } = new List<UpdateMediaItemDto>();
    }
}
