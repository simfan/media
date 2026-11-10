using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class TelevisionEpisodeDto : MediaItemDto
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int? Runtime { get; set; }
        public decimal? Rating { get; set; }

        public CreateTelevisionEpisodeDto ToCreateTelevisionEpisode()
        {
            var newEpisode = new CreateTelevisionEpisodeDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                EpisodeNumber = EpisodeNumber,
                TelevisionShowId = TelevisionShowId,
                SeasonId = SeasonId,
                SeasonNumber = SeasonNumber,
                Director = Director,
                AirDate = AirDate,
                Runtime = Runtime,
                Rating = Rating
            };
            return newEpisode;
        }

        public UpdateTelevisionEpisodeDto ToUpdateTelevisionEpisode()
        {
            var updatedEpisode = new UpdateTelevisionEpisodeDto()
            {
                EpisodeId = EpisodeId,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                EpisodeNumber = EpisodeNumber,
                TelevisionShowId = TelevisionShowId,
                SeasonId = SeasonId,
                SeasonNumber = SeasonNumber,
                Director = Director,
                AirDate = AirDate,
                Runtime = Runtime,
                Rating = Rating
            };
            return updatedEpisode;
        }

        public TelevisionEpisodeDto LoadFromMediaItemDto(MediaItemDto mediaItemDto)
        {
            return new TelevisionEpisodeDto()
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

    public class CreateTelevisionEpisodeDto :CreateMediaItemDto
    {
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int? Runtime { get; set; }
        public decimal? Rating { get; set; }
    }

    public class UpdateTelevisionEpisodeDto : UpdateMediaItemDto
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int? Runtime { get; set; }
        public decimal? Rating { get; set; }

        public CreateTelevisionEpisodeDto ToCreateTelevisionEpisode()
        {
            var newEpisode = new CreateTelevisionEpisodeDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                EpisodeNumber = EpisodeNumber,
                TelevisionShowId = TelevisionShowId,
                SeasonId = SeasonId,
                SeasonNumber = SeasonNumber,
                Director = Director,
                AirDate = AirDate,
                Runtime = Runtime,
                Rating = Rating
            };
            return newEpisode;
        }

    }

}
