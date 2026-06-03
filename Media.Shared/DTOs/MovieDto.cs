using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MovieDto:MediaItemDto
    { 
        public int MovieId { get; set; } //this will remain hidden
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
    }

    public class CreateMovieDto:CreateMediaItemDto
    {
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
    }
    public class UpdateMovieDto:UpdateMediaItemDto
    {
        public int MovieId { get; set; } //this will remain hidden
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public CreateMovieDto ToCreateMovie()
        {
            var newMovie = new CreateMovieDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                Runtime = Runtime,
                ReleaseDate = ReleaseDate,
                Director = Director,
                Studio = Studio,
                Genre = Genre,
                Rating = Rating
            };
            return newMovie;
        }

        public UpdateMovieDto LoadFromCreate(CreateMovieDto createMovie, UpdateMovieDto existingMovie)
        {
            existingMovie.Title = createMovie.Title;
            existingMovie.Description = createMovie.Description;
            existingMovie.MediaType = createMovie.MediaType;
            existingMovie.LibraryId = createMovie.LibraryId;
            existingMovie.ThumbnailPath = createMovie.ThumbnailPath;
            return existingMovie;
        }
    }


}
