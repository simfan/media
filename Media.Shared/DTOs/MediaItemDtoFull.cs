using Medias.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MediaItemDtoFull
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int? LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<MediaFileDto>? MediaFiles { get; set; }
        public LibraryDto Library { get; set; }
        public MovieDetailsDto? MovieDetails { get; set; }

        public MediaItemDto ToMediaItemDto ()
        {
            var mediaItemDto = new MediaItemDto() 
            {
                Id = Id,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
            };

            return mediaItemDto;
        }

        public MovieDto ToMovieDto()
        {
            var movieDto = new MovieDto()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                Runtime = MovieDetails.Runtime,
                ReleaseDate = MovieDetails.ReleaseDate,
                Director = MovieDetails.Director,
                Studio = MovieDetails.Studio,
                Genre = MovieDetails.Genre,
                Rating = MovieDetails.Rating
            };
            return movieDto;
        }
    }

    public class MovieDetailsDto
    {
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }

    }
}
