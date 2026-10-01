using System;
using System.Collections.Generic;
using System.Text;
using Medias.Data.Entities;
using Medias.Shared.DTOs;


namespace Medias.Data.Conversions
{
    public static class MovieConversions
    {
        public static MovieDetail ToMovieDetail(this MovieDto dto)
        {
            return new MovieDetail
            {
                MediaItemId = dto.Id,
                Runtime = dto.Runtime,
                ReleaseDate = dto.ReleaseDate,
                Director = dto.Director,
                Studio = dto.Studio,
                Genre = dto.Genre,
                Rating = dto.Rating
            };
        }

        public static MovieDetail CreateDtoToMovieDetail(this CreateMovieDto dto, int mediaItemId)
        {
            return new MovieDetail
            {
                MediaItemId = mediaItemId,
                Runtime = dto.Runtime,
                ReleaseDate = dto.ReleaseDate,
                Director = dto.Director,
                Studio = dto.Studio,
                Genre = dto.Genre,
                Rating = dto.Rating
            };
        }

        public static MovieDetail UpdateDtoToMovieDetail(this UpdateMovieDto dto, MovieDetail existingEntity)
        {
            existingEntity.Runtime = dto.Runtime;
            existingEntity.ReleaseDate = dto.ReleaseDate;
            existingEntity.Director = dto.Director;
            existingEntity.Studio = dto.Studio;
            existingEntity.Genre = dto.Genre;
            existingEntity.Rating = dto.Rating;
            return existingEntity;
        }

        public static MovieDto ToMovieDto(MediaItem mediaItem)
        {
            MovieDto movieDto = new MovieDto();
            
            var movieDetail = mediaItem.MovieDetail;
            var mediaItemDto = mediaItem.ToMediaItemDto();
            //movieDto = (MovieDto)mediaItem.ToMediaItemDto();
            movieDto = movieDto.LoadFromMediaItemDto(mediaItemDto);
            movieDto.Runtime = movieDetail.Runtime;
            movieDto.ReleaseDate = movieDetail.ReleaseDate;
            movieDto.Director = movieDetail.Director;
            movieDto.Studio = movieDetail.Studio;
            movieDto.Genre = movieDetail.Genre;
            movieDto.Rating = movieDetail.Rating;
            return movieDto;
        }


    }
}
