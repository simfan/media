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

        public CreateTelevisionShowDto ToCreateTelevisionShow()
        {
            var newTVShow = new CreateTelevisionShowDto()
            {
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
            return newTVShow;
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
            return newShow;
        }

        public UpdateTelevisionShowDto LoadFromCreate(CreateTelevisionShowDto createTelevisionShow, UpdateTelevisionShowDto existingTelevisionShow)
        {
            existingTelevisionShow.Title = createTelevisionShow.Title;
            existingTelevisionShow.Description = createTelevisionShow.Description;
            existingTelevisionShow.MediaType = createTelevisionShow.MediaType;
            existingTelevisionShow.LibraryId = createTelevisionShow.LibraryId;
            existingTelevisionShow.ThumbnailPath = createTelevisionShow.ThumbnailPath;
            existingTelevisionShow.CreatedBy = createTelevisionShow.CreatedBy;
            existingTelevisionShow.Studio = createTelevisionShow.Studio;
            existingTelevisionShow.Genre = createTelevisionShow.Genre;
            existingTelevisionShow.Rating = createTelevisionShow.Rating;
            existingTelevisionShow.Status = createTelevisionShow.Status;
            existingTelevisionShow.TmdbTvId = createTelevisionShow.TmdbTvId;
            existingTelevisionShow.ImdbId = createTelevisionShow.ImdbId;
            existingTelevisionShow.SeasonCount = createTelevisionShow.SeasonCount;
            return existingTelevisionShow;
        }

    }



}
