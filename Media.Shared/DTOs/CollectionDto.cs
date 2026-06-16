using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Medias.Shared.Enums;

namespace Medias.Shared.DTOs
{
    public class CollectionDto
    {
        public int CollectionId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public CollectionTypeValue CollectionMediaType { get; set; }
        public string? CoverImageURL { get; set; }
        public List<MediaItemDto>? Items { get; set; }
    }
}
