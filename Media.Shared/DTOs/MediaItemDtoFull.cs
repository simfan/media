using Medias.Shared.Enums;
using Medias.Shared.Helpers;
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
        public TelevisionShowDto? TelevisionShowDetails { get; set; }
        public MusicDto? MusicDetails { get; set; }
        public List<CollectionDto> Collections { get; set; }
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

        public TelevisionShowDto ToTelevisionShowDto(MediaItemDtoFull existingItem)
        {
            var televisionShowDto = new TelevisionShowDto()
            {
                Id = existingItem.Id,
                Title = existingItem.Title,
                Description = existingItem.Description,
                MediaType = existingItem.MediaType,
                LibraryId = existingItem.LibraryId,
                ThumbnailPath = existingItem.ThumbnailPath,
                CreatedBy = existingItem.TelevisionShowDetails.CreatedBy,
                Studio = existingItem.TelevisionShowDetails.Studio,
                Genre = existingItem.TelevisionShowDetails.Genre,
                Rating = existingItem.TelevisionShowDetails.Rating,
                Status = existingItem.TelevisionShowDetails.Status,
                TmdbTvId = existingItem.TelevisionShowDetails.TmdbTvId,
                ImdbId = existingItem.TelevisionShowDetails.ImdbId,
                SeasonCount = existingItem.TelevisionShowDetails.SeasonCount,
            };
            if(existingItem.TelevisionShowDetails.Seasons != null && existingItem.TelevisionShowDetails.Seasons.Count() > 0)
            {
                foreach (var season in existingItem.TelevisionShowDetails.Seasons)
                {
                    televisionShowDto?.Seasons?.Add(season);
                }
            }
            return televisionShowDto;
        }

        public MusicDto ToMusicDto()
        {
            var musicDto = new MusicDto()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                Artist = MusicDetails?.Artist,
                Writer = MusicDetails?.Writer,
                Studio = MusicDetails?.Studio,
                Genre = MusicDetails?.Genre,
                RuntimeMinutes = MusicDetails.RuntimeMinutes,
                RuntimeSeconds = MusicDetails.RuntimeSeconds,
                FirstReleased = MusicDetails.FirstReleased,
                Rating = MusicDetails.Rating,
                CoverArtPath = MusicDetails.CoverArtPath,
                MusicBrainzRecordingId = MusicDetails.MusicBrainzRecordingId
            };
            return musicDto;

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
