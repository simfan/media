using System;
using System.Collections.Generic;
using System.Text;
using Media.Shared;
using Medias.Shared.DTOs;

namespace Medias.Shared.DTOs
{
    public class TelevisionShowDto : CollectionDto
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
        public List<TelevisionEpisodeDto>? Episodes { get; set; }

        public CreateTelevisionShowDto ToCreateTelevisionShow()
        {
            var newShow = new CreateTelevisionShowDto()
            {
                Name = Name,
                Description = Description,
                //CollectionMediaType = CollectionMediaType,
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

        public TelevisionShowDto LoadFromCollectionDto(CollectionDto collectionDto)
        {
            return new TelevisionShowDto()
            {
                CollectionId = collectionDto.CollectionId,
                Name = collectionDto.Name,
                Description = collectionDto.Description,
                CreatedDate = collectionDto.CreatedDate,
                UpdatedDate = collectionDto.UpdatedDate,
                CollectionMediaType = collectionDto.CollectionMediaType,

            };
        }
    }

    public class CreateTelevisionShowDto : CreateCollectionDto
    {
        public string CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set; }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }
        public List<CreateTelevisionSeasonDto>? Seasons { get; set; }
        public List<CreateTelevisionEpisodeDto>? Episodes { get; set; }
    }

    public class UpdateTelevisionShowDto : UpdateCollectionDto
    {
        public string? CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set; }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }
        public List<UpdateTelevisionSeasonDto>? Seasons { get; set; }
        public List<UpdateTelevisionEpisodeDto>? Episodes { get; set; }

        public CreateTelevisionShowDto ToCreateTelevisionShow()
        {
            var newShow = new CreateTelevisionShowDto()
            {
                Name = Name,
                Description = Description,
                CreatedBy = CreatedBy,
                Studio = Studio,
                Genre = Genre,
                Rating = Rating,
                Status = Status,
                TmdbTvId = TmdbTvId,
                ImdbId = ImdbId,
                SeasonCount = SeasonCount
            };

            if(Seasons != null)
            {
               newShow.Seasons = new List<CreateTelevisionSeasonDto>();
                foreach (var season in Seasons)
                {
                    var newSeason = season.ToCreateTelevisionSeason();
                    newShow.Seasons.Add(newSeason);
                }
            }

            if(Episodes != null)
            {
                newShow.Episodes = new List<CreateTelevisionEpisodeDto>();
                foreach (var episode in Episodes)
                {
                    var newEpisode = episode.ToCreateTelevisionEpisode();
                    newShow.Episodes.Add(newEpisode);
                }
            }
            return newShow;
        }

        public UpdateTelevisionShowDto ToUpdateTelevisionShow()
        {
            var updatedTelevisionShow = new UpdateTelevisionShowDto()
            {
                CollectionId = CollectionId,
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

        public UpdateTelevisionShowDto LoadFromCreate(CreateTelevisionShowDto createShow, UpdateTelevisionShowDto existingShow)
        {
            return new UpdateTelevisionShowDto()
            {
                CollectionId = existingShow.CollectionId,
                Name = createShow.Name,
                Description = createShow.Description,
                CreatedBy = createShow.CreatedBy,
                Studio = createShow.Studio,
                Genre = createShow.Genre,
                Rating = createShow.Rating,
                Status = createShow.Status,
                TmdbTvId = createShow.TmdbTvId,
                ImdbId = createShow.ImdbId,
                SeasonCount = createShow.SeasonCount
            };
        }
    }
    public class ImportTelevisionShowResultsDto
    {
        public UpdateTelevisionShowDto TMDbShow{ get; set; }
        public UpdateTelevisionShowDto? UpdateTelevisionShow { get; set; }
        public bool ExistsInLibrary { get; set; }
    }
}
