using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Medias.Shared.DTOs;

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
    }
}
