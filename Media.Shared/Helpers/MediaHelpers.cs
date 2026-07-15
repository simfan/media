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

        public static string GetCollectionColor(CollectionMediaTypeValue collectionType)
        {
            return collectionType switch
            {
                CollectionMediaTypeValue.Movie => "#DC3545", //Red
                CollectionMediaTypeValue.TV => "#0D6EFD",    //Blue
                CollectionMediaTypeValue.Music => "#198754",  //Green
                CollectionMediaTypeValue.Book => "#FD7E14",   //Orange
                CollectionMediaTypeValue.Photo => "#6F42C1",  //Purple
                CollectionMediaTypeValue.Document => "#6C757D", //Gray
                CollectionMediaTypeValue.Podcast => "#20C997", //Teal
                CollectionMediaTypeValue.Other => "#FFFFFF",   //Black
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

        public static string GetCollectionClass(this CollectionMediaTypeValue collectionType)
        {
            return collectionType switch
            {
                CollectionMediaTypeValue.Movie => "collection-movie", //Red
                CollectionMediaTypeValue.TV => "collection-tv",    //Blue
                CollectionMediaTypeValue.Music => "collection-music",  //Green
                CollectionMediaTypeValue.Book => "collection-book",   //Orange
                CollectionMediaTypeValue.Photo => "collection-photo",  //Purple
                CollectionMediaTypeValue.Document => "collection-document", //Gray
                CollectionMediaTypeValue.Podcast => "collection-podcast", //Teal
                CollectionMediaTypeValue.Mixed => "collection-mixed",   //Black
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
