using System;
using System.Collections.Generic;
using System.Text;
using Medias.Shared.Enums;

namespace Medias.Shared.Helpers
{
    public static class MediaHelpers
    {
        public static string GetMediaColor(MediaTypeValue mediaType)
        {
            return mediaType switch
            {
                MediaTypeValue.Movie => "#DC3545", //Red
                MediaTypeValue.TV => "#0D6EFD",    //Blue
                MediaTypeValue.Music => "#198754",  //Green
                MediaTypeValue.Book => "#FD7E14",   //Orange
                MediaTypeValue.Photo => "#6F42C1",  //Purple
                MediaTypeValue.Document => "#6C757D", //Gray
                MediaTypeValue.Podcast => "#20C997", //Teal
                MediaTypeValue.Other => "#FFFFFF",   //Black
                _ => "#FFFFFF"
            };
        }

        public static string GetCollectionColor(CollectionTypeValue collectionType)
        {
            return collectionType switch
            {
                CollectionTypeValue.Movie => "#DC3545", //Red
                CollectionTypeValue.TV => "#0D6EFD",    //Blue
                CollectionTypeValue.Music => "#198754",  //Green
                CollectionTypeValue.Book => "#FD7E14",   //Orange
                CollectionTypeValue.Photo => "#6F42C1",  //Purple
                CollectionTypeValue.Document => "#6C757D", //Gray
                CollectionTypeValue.Podcast => "#20C997", //Teal
                CollectionTypeValue.Other => "#FFFFFF",   //Black
                _ => "#212529"
            };
        }

        public static string GetMediaClass(this MediaTypeValue mediaType)
        {
            return mediaType switch
            {
                MediaTypeValue.Movie => "media-movie", //Red
                MediaTypeValue.TV => "media-tv",    //Blue
                MediaTypeValue.Music => "media-music",  //Green
                MediaTypeValue.Book => "media-book",   //Orange
                MediaTypeValue.Photo => "media-photo",  //Purple
                MediaTypeValue.Document => "media-document", //Gray
                MediaTypeValue.Podcast => "media-podcast", //Teal
                _ => "media-other"
            };
        }

        public static string GetCollectionClass(this CollectionTypeValue collectionType)
        {
            return collectionType switch
            {
                CollectionTypeValue.Movie => "collection-movie", //Red
                CollectionTypeValue.TV => "collection-tv",    //Blue
                CollectionTypeValue.Music => "collection-music",  //Green
                CollectionTypeValue.Book => "collection-book",   //Orange
                CollectionTypeValue.Photo => "collection-photo",  //Purple
                CollectionTypeValue.Document => "collection-document", //Gray
                CollectionTypeValue.Podcast => "collection-podcast", //Teal
                CollectionTypeValue.Mixed => "collection-mixed",   //Black
                _ => "collection-other"
            };
        }

        public static string GetCollectionBackground(IEnumerable<MediaTypeValue> mediaTypes) {
            var colors = mediaTypes
                .Select(GetMediaColor)
                .Distinct()
                .ToList();
            if(colors.Count == 1)
            {
                return colors.First();
            }
            return $"linear-gradient(135deg, {string.Join(", ", colors)})";
        }

        
    }
}
