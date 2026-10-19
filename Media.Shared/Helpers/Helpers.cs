using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Medias.Shared.Helpers
{
    public static class Helpers
    {
        public static string GetDisplayName(this Enum value)
        {
            return (value.GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute)
                ?.Name
                ?? value.ToString();
        }

        public static DateTime ToDateTime(string dateTimeString)
        {
            string format = "yyyy-MM-dd";
            DateTime convertedDate = DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture);
            return convertedDate;
        }

        public static int TimeToMinutes(int timeInSeconds)
        {
            int minutes = timeInSeconds / 60;
            return minutes;
        }

        public static int TimeToRemainingSeconds(int timeInSeconds)
        {
            int remainingSeconds = timeInSeconds % 60;
            return remainingSeconds;
        }

        public static int TimeToSeconds(int minutes, int remainingSeconds)
        {
            int minutesInSeconds = minutes * 60;
            int totalTime = minutesInSeconds + remainingSeconds;
            return totalTime;
        }

        public static void CopyBaseProperties(MediaItemDto source, MediaItemDto target)
        {
            target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            target.LibraryId = source.LibraryId;
            target.ThumbnailPath = source.ThumbnailPath;
            target.CreatedDate = source.CreatedDate;
            target.UpdatedDate = source.UpdatedDate;
        }

        public static void CopyCreatedBaseProperties(CreateMediaItemDto source, CreateMediaItemDto target)
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.LibraryId = source.LibraryId;
            target.ThumbnailPath = source.ThumbnailPath;
        }

        public static void CopyUpdatedBaseProperites(UpdateMediaItemDto source, UpdateMediaItemDto target)
        {
            target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            target.LibraryId = source.LibraryId;
            target.ThumbnailPath = source.ThumbnailPath;
        }

        public static T MediaItemConverter<T>(MediaItemDto source) where T : MediaItemDto, new()
        {
            var target = new T();
            CopyBaseProperties(source, target);
            return target;
        }

        public static T CreateMediaItemConverter<T>(CreateMediaItemDto source) where T : CreateMediaItemDto, new()
        {
            var target = new T();
            CopyCreatedBaseProperties(source, target);
            return target;
        }
        
        public static T UpdateMediaItemConverter<T>(UpdateMediaItemDto source) where T : UpdateMediaItemDto, new()
        {
            var target = new T();
            CopyUpdatedBaseProperites(source, target);
            return target;
        }

        public static double CalculateTitleMatch(string searchTitle, string resultTitle) 
        {
            if(string.IsNullOrWhiteSpace(searchTitle) || string.IsNullOrWhiteSpace(resultTitle))
            {
                return 0;
            }

            if(string.Equals(searchTitle,resultTitle, StringComparison.OrdinalIgnoreCase))
            {
                return 100;
            }


            //int distance = Math.LevenshteinDistance(searchTitle.ToLowerInvariant(), resultTitle.ToLowerInvariant());
            // Convert Levenshtein distance to a similarity score (0-100)
            int maxLength = Math.Max(searchTitle.Length, resultTitle.Length);
            return Math.Round(100.0 * (1.0 - (double)maxLength / maxLength), 1);
        }

    }
}
