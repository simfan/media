using System;
using System.Collections.Generic;
using System.Text;
using Media.Shared;
using Medias.Shared.DTOs;

namespace Medias.Shared.DTOs
{
    public class TelevisionShowDto : MediaItemDto
    {
        public string CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set;  }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }
        public List<TelevisionSeasonDto>? Seasons { get; set; }

        public TelevisionShowDto LoadFromMediaItemDto(MediaItemDto mediaItemDto)
        {
            return new TelevisionShowDto()
            {
                Id = mediaItemDto.Id,
                Title = mediaItemDto.Title,
                Description = mediaItemDto.Description,
                MediaType = Enums.MediaTypeValue.TV,
                LibraryId = mediaItemDto.LibraryId,
                ThumbnailPath = mediaItemDto.ThumbnailPath
            };
        }

        public UpdateTelevisionShowDto ToUpdateTelevisionShow()
        {
            var updatedTelevisionShow = new UpdateTelevisionShowDto()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                CreatedBy = CreatedBy,
                Studio = Studio,
                Genre = Genre,
                Rating = Rating,
                Status = Status,
                TmdbTvId = TmdbTvId,
                ImdbId = ImdbId,
                SeasonCount = SeasonCount
            };
            return updatedTelevisionShow;
        }
    }

    public class TelevisionSeasonDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
        public List<TelevisionEpisodeDto>? Episodes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class TelevisionEpisodeDto
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int Runtime { get; set; }
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
    public class CreateTelevisionShowDto :CreateMediaItemDto
    {
        public string CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set; }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }
    }

    public class UpdateTelevisionShowDto : UpdateMediaItemDto
    {
        public string? CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set; }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }

        public CreateTelevisionShowDto ToCreateTelevisionShow()
        {
            var newShow = new CreateTelevisionShowDto()
            {
                CreatedBy = CreatedBy,
                Studio = Studio,
                Genre = Genre,
                Rating = Rating,
                Status = Status,
                TmdbTvId = TmdbTvId,
                ImdbId = ImdbId,
                SeasonCount = SeasonCount

            };
            return newShow;
        }

        public UpdateTelevisionShowDto LoadFromCreate(CreateTelevisionShowDto createTelevisionShow, UpdateTelevisionShowDto existingTelevisionShow)
        {
            existingTelevisionShow.Title = createTelevisionShow.Title;
            existingTelevisionShow.Description = createTelevisionShow.Description;
            existingTelevisionShow.MediaType = createTelevisionShow.MediaType;
            existingTelevisionShow.LibraryId = createTelevisionShow.LibraryId;
            existingTelevisionShow.ThumbnailPath = createTelevisionShow.ThumbnailPath;
            return existingTelevisionShow;
        }

    }

    public class CreateTelevisionSeasonDto
    {
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
    }

    public class CreateTelevisionEpisodeDto
    {
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int Runtime { get; set; }
        public decimal? Rating { get; set; }
    }

    public class UpdateTelevisionSeasonDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
    }

    public class UpdateTelevisionEpisodeDto
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Director { get; set; }
        public DateTime? AirDate { get; set; }
        public int Runtime { get; set; }
        public decimal? Rating { get; set; }

    }


}
