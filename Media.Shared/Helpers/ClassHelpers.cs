using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.Helpers
{
    internal class ClassHelpers
    {
        /* 
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
        }*/
    }
}
