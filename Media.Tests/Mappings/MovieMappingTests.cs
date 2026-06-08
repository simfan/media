using System;
using System.Collections.Generic;
using System.Text;
using Medias.Data.Entities;
using Medias.Data.Conversions;
using Xunit;
namespace Medias.Tests.Mappings
{
    public class MovieMappingTests
    {
        [Fact]
        public void MapsDirectorCorrectly()
        {
            var entity = new MovieDetail
            {
                Director = "Christopher Nolan",
                Runtime = 200,
                Genre = "Sci-Fi",
            };

            var dto = entity.ToMovieDetailsDto();
            Assert.Equal("Christopher Nolan", dto.Director);
            Assert.Equal(200, dto.Runtime);
            Assert.Equal("Sci-Fi", dto.Genre);
        }
    }
}
