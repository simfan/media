using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MovieDto:MediaItemDto
    { 
        //public int MovieId { get; set; } //this will remain hidden
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Location { get; set; }
        public int? TmdbMovieId { get; set; }
        public string?ImdbId { get; set; }
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
                Rating = Rating,
                TmdbMovieId = TmdbMovieId,
                ImdbId = ImdbId,
            };
            return newMovie;
        }

        public UpdateMovieDto ToUpdateMovie()
        {
               var updatedMovie = new UpdateMovieDto()
            {
                Id = Id,
                //MovieId = MovieId,
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
                Rating = Rating,
            };
            return updatedMovie;
        }

        public MovieDto LoadFromMediaItemDto(MediaItemDto mediaItemDto)
        {
            return new MovieDto()
            {
                Id = mediaItemDto.Id,
                Title = mediaItemDto.Title,
                Description = mediaItemDto.Description,
                MediaType = Enums.MediaTypeValue.Movie,
                LibraryId = mediaItemDto.LibraryId,
                ThumbnailPath = mediaItemDto.ThumbnailPath
            };
        }
    }

    public class CreateMovieDto:CreateMediaItemDto
    {
        public int Runtime { get; set; } // in minutes
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public int? TmdbMovieId { get; set; }
        public string? ImdbId { get; set; }

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
        public int? TmdbMovieId { get; set; }
        public string? ImdbId { get; set; }
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
                Rating = Rating,
                TmdbMovieId = TmdbMovieId,
                ImdbId = ImdbId
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
            existingMovie.Runtime = createMovie.Runtime;
            existingMovie.ReleaseDate = createMovie.ReleaseDate;
            existingMovie.Director = createMovie.Director;
            existingMovie.Studio = createMovie.Studio;
            existingMovie.Genre = createMovie.Genre;
            existingMovie.Rating = createMovie.Rating;
            existingMovie.TmdbMovieId = createMovie.TmdbMovieId;
            existingMovie.ImdbId = createMovie.ImdbId;
            return existingMovie;
        }

        public UpdateMovieDto LoadFromMediaItemDto(UpdateMovieDto updateMovieDto, MediaItemDto mediaItemDto)
        {
            updateMovieDto.Title = mediaItemDto.Title;
            updateMovieDto.Description = mediaItemDto.Description;
            updateMovieDto.MediaType = mediaItemDto.MediaType;
            updateMovieDto.LibraryId = mediaItemDto.LibraryId;
            updateMovieDto.ThumbnailPath = mediaItemDto.ThumbnailPath;
            //var movieDetails = mediaItemDto.movieDetails;
            return updateMovieDto;
        }
        
    }

    public class ImportMovieResultsDto
    {
        public UpdateMovieDto TMDbMovie { get; set; }
        public UpdateMovieDto? ExisitingMovie { get; set; }
        public bool ExistsInLibrary { get; set; }
    }
}
