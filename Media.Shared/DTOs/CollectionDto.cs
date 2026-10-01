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
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public CollectionMediaTypeValue CollectionMediaType { get; set; }
       // public string? CoverImageURL { get; set; }
        public List<MediaItemDto>? Items { get; set; }
    }

    public class CreateCollectionDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        //public CollectionTypeValue? CollectionType { get; set; } = CollectionTypeValue.Default;
    }

    public class UpdateCollectionDto 
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
