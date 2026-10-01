using Medias.Shared.DTOs;
using Medias.Shared.Enums;
using Medias.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOConversions
{
    public static class TMDbConversions 
    {
        public static UpdateMovieDto ToUpdateMovieDto(this TMDbMovieSearchRecord movieDto)
        {
            return new UpdateMovieDto
            {
                Id = 0,
                Title = movieDto.Title,
                Description = movieDto.Overview,
                MediaType = MediaTypeValue.Movie,
                ReleaseDate = Helpers.Helpers.ToDateTime((string) movieDto.Release_Date),
                TmdbMovieId = movieDto.ID
            };
        }
    }
}
