using Medias.Data.Entities;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class TelevisionConversions
    {
        public static TelevisionShowDetail ToTelevisonDetail(this TelevisionShowDto televisionShowDto)
        {
           // televisionShowDto.CollectionId = televisionShowDto.CollectionId;
            var tvShow =  new TelevisionShowDetail
            {
                
                //MediaItemId = televisionShowDto.Id,
                //CollectionId = televisionShowDto.CollectionId,
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

            /*if(televisionShowDto.Episodes != null && televisionShowDto.Episodes.Count > 0)
            {
                foreach (var episodeDto in televisionShowDto.Episodes)
                {
                    var episode = episodeDto.ToEpisode();
                    tvShow?.Episodes?.Add(episode);
                }
            }*/
            return tvShow;
        }

        public static TelevisionSeason ToTelevisionSeason(this TelevisionSeasonDto televisionSeasonDto)
        {
            var televisionSeason = new TelevisionSeason
            {
                SeasonId = televisionSeasonDto.SeasonId,
                //MediaItemId = televisionSeasonDto.TelevisionShowId,
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
                //MediaItemId = mediaItemId,
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
        /*public static TelevisionShowDto ToTelevisionShowDto(MediaItem mediaItem)
        {
            TelevisionShowDto televisionShowDto = new TelevisionShowDto();
            //var televisionShowDetail = mediaItem.TelevisionShowDetail;
            var mediaItemDto = mediaItem.ToMediaItemDto();
            //televisionShowDto.LoadFromMediaItemDto(mediaItemDto);
            televisionShowDto.CreatedBy = televisionShowDetail.CreatedBy;
            televisionShowDto.Studio = televisionShowDetail.Studio;
            televisionShowDto.Genre = televisionShowDetail.Genre;
            televisionShowDto.Rating = televisionShowDetail.Rating;
            televisionShowDto.Status = televisionShowDetail.Status;
            televisionShowDto.TmdbTvId = televisionShowDto.TmdbTvId;
            televisionShowDto.ImdbId =  televisionShowDto.ImdbId;
            televisionShowDto.SeasonCount = televisionShowDetail.SeasonCount;
            return televisionShowDto;
        }*/
        public static TelevisionShowDto ToTelevisionShowDto(this Collection collection)
        {
            TelevisionShowDto televisionShowDto = new TelevisionShowDto();
            var televisionShowDetail = collection.TelevisionShowDetail;
            var collectionDto = collection.ToCollectionDto();
            televisionShowDto =  televisionShowDto.LoadFromCollectionDto(collectionDto);
            televisionShowDto.CreatedBy = televisionShowDetail.CreatedBy;
            televisionShowDto.Studio = televisionShowDetail.Studio;
            televisionShowDto.Genre = televisionShowDetail.Genre;
            televisionShowDto.Rating = televisionShowDetail.Rating;
            televisionShowDto.Status = televisionShowDetail.Status;
            televisionShowDto.TmdbTvId = televisionShowDetail.TmdbTvId;
            televisionShowDto.ImdbId = televisionShowDetail.ImdbId;
            televisionShowDto.SeasonCount = televisionShowDetail.SeasonCount;
            return televisionShowDto;
        }

        public static TelevisionSeasonDto ToTelevisionSeasonDto(this Collection collection)
        { 
            TelevisionSeasonDto televisionSeasonDto = new TelevisionSeasonDto();
            var televisionSeasonDetail = collection.TelevisionSeason;
            var collectionDto = collection.ToCollectionDto();
            televisionSeasonDto = televisionSeasonDto.LoadFromCollectionDto(collectionDto);
            televisionSeasonDto.SeasonId = televisionSeasonDetail.SeasonId;
            televisionSeasonDto.SeasonNumber = televisionSeasonDetail.SeasonNumber;
            televisionSeasonDto.Name = televisionSeasonDetail.Name;
            televisionSeasonDto.Description = televisionSeasonDetail.Description;
            televisionSeasonDto.EpisodeCount = televisionSeasonDetail.EpisodeCount;
            return televisionSeasonDto; 
        }
        public static TelevisionShowDetail UpdateDtoToTelevisionShowDetail(this UpdateTelevisionShowDto dto, TelevisionShowDetail existingEntity)
        {
            existingEntity.CreatedBy = dto.CreatedBy;
            existingEntity.Studio = dto.Studio;
            existingEntity.Genre = dto.Genre;
            existingEntity.Rating = dto.Rating;
            existingEntity.Status = dto.Status;
            existingEntity.TmdbTvId = dto.TmdbTvId;
            existingEntity.ImdbId = dto.ImdbId;
            existingEntity.SeasonCount = dto.SeasonCount;
            return existingEntity;
        }

        public static TelevisionSeason UpdateDtoToTelevisionSeason(this UpdateTelevisionSeasonDto dto, TelevisionSeason existingEntity)
        {
            existingEntity.SeasonNumber = dto.SeasonNumber;
            existingEntity.Name = dto.Name;
            existingEntity.Description = dto.Description;
            existingEntity.EpisodeCount = dto.EpisodeCount;
            return existingEntity;
        }

        public static TelevisionEpisode UpdateDtoToTelevisionEpisode(this UpdateTelevisionEpisodeDto dto, TelevisionEpisode existingEntity)
        {
            existingEntity.EpisodeNumber = dto.EpisodeNumber;
            existingEntity.Title = dto.Title;
            existingEntity.Description = dto.Description;
            existingEntity.Director = dto.Director;
            existingEntity.Runtime = dto.Runtime;
            existingEntity.Rating = dto.Rating;
            existingEntity.AirDate = dto.AirDate;
            return existingEntity;
        }

        public static TelevisionEpisodeDto ToTelevisionEpisodeDto(MediaItem mediaItem)
        {

            TelevisionEpisodeDto televisionEpisodeDto = new TelevisionEpisodeDto();
            //televisionEpisodeDto = mediaItem.ToMediaItemDto();
            var televisionEpisodeDetail = mediaItem.TelevisionEpisode;
            var mediaItemDto = mediaItem.ToMediaItemDto();
            televisionEpisodeDto.LoadFromMediaItemDto(mediaItemDto);
            televisionEpisodeDto.EpisodeNumber = televisionEpisodeDetail.EpisodeNumber;
            televisionEpisodeDto.Title = televisionEpisodeDetail.Title;
            televisionEpisodeDto.Description = televisionEpisodeDetail.Description;
            televisionEpisodeDto.Director = televisionEpisodeDetail.Director;
            televisionEpisodeDto.Runtime = televisionEpisodeDetail.Runtime;
            televisionEpisodeDto.Rating = televisionEpisodeDetail.Rating;
            televisionEpisodeDto.AirDate = televisionEpisodeDetail.AirDate;
            return televisionEpisodeDto;
        }

        public static TelevisionEpisode CreateDtoToTelevisionEpisode(this CreateTelevisionEpisodeDto dto, int mediaItemId)
        {

            return new TelevisionEpisode
            {
                MediaItemId = mediaItemId,
                //EpisodeId = 
                EpisodeNumber = dto.EpisodeNumber,
                TelevisionShowId = dto.TelevisionShowId,
                SeasonId = dto.SeasonId,
                SeasonNumber = dto.SeasonNumber,
                Title = dto.Title,
                Description = dto.Description,
                Director = dto.Director,
                AirDate = dto.AirDate,
                Runtime = dto.Runtime,
                Rating = dto.Rating

                //Barcode = null
            };
        }
    }
}
