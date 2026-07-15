using Medias.Server.DTOs;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using System;
using System.Globalization;

namespace Medias.Server.Conversions
{
    public static class TMDbConversions
    {
        public static UpdateMovieDto ToMovieDto(this Medias.Server.DTOs.TMDbMovieResult entity)
        {
            //DateTime releaseDate = DateTime.ParseExact(entity.Release_Date,)
            return new UpdateMovieDto
            {
                Id = 0,
                Title = entity.Title,
                Description = entity.Overview,
                ReleaseDate = ToDateTime((string) entity.Release_Date),
                MediaType = MediaTypeValue.Movie,
                TmdbMovieId = entity.ID
            };
        }

        private static DateTime ToDateTime(string dateTimeString)
        {
            string format = "yyyy-MM-dd";
            DateTime convertedDate = DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture);
            return convertedDate;
        }
    }
}
