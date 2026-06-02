using Medias.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MediaItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        /*public List<MediaFile>? MediaFiles { get; set; }
        public Library Library { get; set; }*/


    }

    public class CreateMediaItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
    }

    public class UpdateMediaItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
    }
}
