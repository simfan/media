using Medias.Data.Entities;
using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class TelevisionConversions
    {
        public static TelevisionShowDetail ToTelevisonDetail(this TelevisionShowDto televisionShowDto)
        {
            var tvShow =  new TelevisionShowDetail
            {
                MediaItemId = televisionShowDto.Id,
                CreatedBy = televisionShowDto.CreatedBy,
                Studio = televisionShowDto.Studio,
                Genre = televisionShowDto.Genre,
                Rating = televisionShowDto.Rating,
                Status =    televisionShowDto.Status,
                TmdbTvId = televisionShowDto.TmdbTvId,
                ImdbId = televisionShowDto.ImdbId,
                SeasonCount = televisionShowDto.SeasonCount,

            };
            if (televisionShowDto.Seasons != null && televisionShowDto.Seasons.Count > 0)
            {
                foreach (var seasonDto in televisionShowDto.Seasons)
                {
                    var season = seasonDto.ToTelevisionSeason();
                    tvShow?.Seasons?.Add(season);
                }
            }
            return tvShow;
        }

        public static TelevisionSeason ToTelevisionSeason(this TelevisionSeasonDto televisionSeasonDto)
        {
            var televisionSeason = new TelevisionSeason
            {
                SeasonId = televisionSeasonDto.SeasonId,
                MediaItemId = televisionSeasonDto.TelevisionShowId,
                SeasonNumber = televisionSeasonDto.SeasonNumber,
                Name = televisionSeasonDto.Name,
                Description = televisionSeasonDto?.Description,
                EpisodeCount = televisionSeasonDto.EpisodeCount

            };
            if (televisionSeasonDto.Episodes != null && televisionSeasonDto.Episodes.Count > 0)
            {
                foreach(var episodeDto in  televisionSeasonDto.Episodes)
                {
                    var episode = episodeDto.ToEpisode();
                    televisionSeason.Episodes?.Add(episode);
                }
            }
            return televisionSeason;
        }

        public static TelevisionEpisode ToEpisode(this TelevisionEpisodeDto televisionEpisodeDto)
        {
            return new TelevisionEpisode
            {
                EpisodeId = televisionEpisodeDto.EpisodeId,
                EpisodeNumber = televisionEpisodeDto.EpisodeNumber,
                TelevisionShowId = televisionEpisodeDto.TelevisionShowId,
                SeasonId = televisionEpisodeDto.SeasonId,
                SeasonNumber = televisionEpisodeDto.SeasonNumber,
                Title = televisionEpisodeDto.Title,
                Description = televisionEpisodeDto.Description,
                Director = televisionEpisodeDto.Director,
                Runtime = televisionEpisodeDto.Runtime,
                Rating = televisionEpisodeDto?.Rating,
                AirDate = televisionEpisodeDto?.AirDate
            };
        }

        public static TelevisionShowDetail CreateDtoToTelevisionShowDetail(this CreateTelevisionShowDto dto, int mediaItemId)
        {
            return new TelevisionShowDetail
            {
                MediaItemId = mediaItemId,
                CreatedBy = dto.CreatedBy,
                Studio = dto.Studio,
                Genre = dto.Genre,
                Rating = dto.Rating,
                Status = dto.Status,
                TmdbTvId = dto.TmdbTvId,
                ImdbId = dto.ImdbId,
                SeasonCount = dto.SeasonCount
            };
        }
        public static TelevisionShowDto ToTelevisionShowDto(MediaItem mediaItem)
        {
            TelevisionShowDto televisionShowDto = new TelevisionShowDto();
            var televisionShowDetail = mediaItem.TelevisionShowDetail;
            var mediaItemDto = mediaItem.ToMediaItemDto();
            televisionShowDto.LoadFromMediaItemDto(mediaItemDto);
            televisionShowDto.CreatedBy = televisionShowDetail.CreatedBy;
            televisionShowDto.Studio = televisionShowDetail.Studio;
            televisionShowDto.Genre = televisionShowDetail.Genre;
            televisionShowDto.Rating = televisionShowDetail.Rating;
            televisionShowDto.Status = televisionShowDetail.Status;
            televisionShowDto.TmdbTvId = televisionShowDto.TmdbTvId;
            televisionShowDto.ImdbId =  televisionShowDto.ImdbId;
            televisionShowDto.SeasonCount = televisionShowDetail.SeasonCount;
            return televisionShowDto;
        }
    }
}
