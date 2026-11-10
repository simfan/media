using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class TelevisionSeasonDto : CollectionDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeCount { get; set; }
        public List<TelevisionEpisodeDto>? Episodes { get; set; }
        public TelevisionSeasonDto LoadFromCollectionDto(CollectionDto collectionDto)
        {
            return new TelevisionSeasonDto()
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

    public class CreateTelevisionSeasonDto : CreateCollectionDto
    {
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        //public string? Name { get; set; }
        //public string? Description { get; set; }
        public int EpisodeCount { get; set; }
        public List<CreateTelevisionEpisodeDto>? Episodes { get; set; }
    }

    public class UpdateTelevisionSeasonDto : UpdateCollectionDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        //public string? Name { get; set; }
        //public string? Description { get; set; }
        public int EpisodeCount { get; set; }
        public List<UpdateTelevisionEpisodeDto>? Episodes { get; set; }



        public CreateTelevisionSeasonDto ToCreateTelevisionSeason()
        {
            var newSeason = new CreateTelevisionSeasonDto()
            {
                TelevisionShowId = TelevisionShowId,
                SeasonNumber = SeasonNumber,
                Name = Name,
                Description = Description,
                EpisodeCount = EpisodeCount,
                Episodes = null // You can choose to load episodes if needed
            };
            return newSeason;
        }

        public UpdateTelevisionSeasonDto LoadFromTelevisionSeasonDto(TelevisionSeasonDto seasonDto)
        {
            return new UpdateTelevisionSeasonDto()
            {
                SeasonId = seasonDto.SeasonId,
                TelevisionShowId = seasonDto.TelevisionShowId,
                SeasonNumber = seasonDto.SeasonNumber,
                Name = seasonDto.Name,
                Description = seasonDto.Description,
                EpisodeCount = seasonDto.EpisodeCount,
                Episodes = null // You can choose to load episodes if needed
            };
        }
    }
}
