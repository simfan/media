using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.Enums
{
    public enum MediaTypeValue
    {
        Movie = 1,
        TV = 2,
        Music = 3,
        Book = 4,
        Photo = 5,
        Document = 6,
        Podcast = 7,
        Other = 99,
    };

    public enum CollectionMediaTypeValue
    {
     
        Movie = 1,
        TV = 2,
        Music = 3,
        Book = 4,
        Photo = 5,
        Document = 6,
        Podcast = 7,
        Other = 99,
        Mixed = 100
    };

    public enum CollectionTypeValue
    {
        Default = 1,
        TvShow = 2,
        TvEpisode = 3,
        Album = 4
    };

}
