using System;
using System.Collections.Generic;
using System.Text;
using Medias.Shared.Enums;
using Medias.Shared.Helpers;
namespace Medias.Tests.Helpers
{
    public class MediaTypeHelperTests
    {
        [Fact]
        public void GetDisplayName_ReturnsMovie_ForMovieType()
        {
            //Arrange
            var mediaType = MediaTypeValue.Movie;

            //Act
            var result = mediaType.GetDisplayName();

            //Assert
            Assert.Equal("Movie", result);
        }
    }
}
