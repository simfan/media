using Medias.Server.DTOs;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Medias.Server.Conversions
{
    public static class SearchConversions
    {
        public static SearachResultDto FromTMDbMovie(this TMDbMovieResult entity)
        {
            var stringId = entity.ID.ToString();
            return new SearachResultDto
            {
                ImportId = stringId,
                Title = entity.Title,
                Description = entity.Overview,
                ReleaseDate = entity.Release_Date,
                MediaType = MediaTypeValue.Movie,
                PosterPath = $"https://image.tmdb.org/t/p/w500{entity.Poster_Path}"
            };
        }

        public static SearachResultDto FromTMDbTV(this TMDbTVResult entity)
        {
            var stringId = entity.ID.ToString();
            return new SearachResultDto
            {
                ImportId = stringId,
                Title = entity.Name,
                Description = entity.Overview,
                ReleaseDate = $"{entity.First_Air_Date} - {entity.Last_Air_Date}",
                MediaType = MediaTypeValue.TV,
                PosterPath = $"https://image.tmdb.org/t/p/w500{entity.Poster_Path}"
            };
        }

        public static SearachResultDto FromMusicBrainzRecording(this MusicBrainzRecording entity)
        {
            return new SearachResultDto
            {
                ImportId = entity.Id.ToString(),
                Title = entity.Title,
                //Description = entity.Description,
                //ReleaseDate = entity.Release_Date,
                MediaType = MediaTypeValue.Music,
                //PosterPath = entity.CoverArtUrl
            };
        }
    }
}
