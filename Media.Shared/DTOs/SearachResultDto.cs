using System;
using System.Collections.Generic;
using System.Text;
using Medias.Shared.Enums;

namespace Medias.Shared.DTOs
{
    public class SearachResultDto
    {
        public string ImportId { get; set; }
        public string Title { get; set; }
        public string? SortTitle { get; set; }
        public string? Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        //public string? ReleaseDateString { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
