using Medias.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MediaItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int? LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<MediaFileDto>? MediaFiles { get; set; }
        public LibraryDto? Library { get; set; }
        //public List<CollectionDto>? Collections { get; set; }
        public CreateMediaItemDto ToCreateMediaItem()
        {
            var newMediaItem = new CreateMediaItemDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath
            };
            return newMediaItem;
        }


        public UpdateMediaItemDto ToUpdateMediaItem()
        {
            var updatedItem = new UpdateMediaItemDto()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath
            };
            return updatedItem;
        }
    }

    public class CreateMediaItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int? LibraryId { get; set; }
        public string ThumbnailPath { get; set; }
    }

    public class UpdateMediaItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaTypeValue MediaType { get; set; }
        public int? LibraryId { get; set; }
        public string ThumbnailPath { get; set; }

        public CreateMediaItemDto ToCreateMediaItem()
        {
             var newMediaItem = new CreateMediaItemDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath
            };
            return newMediaItem;
        }

        public UpdateMediaItemDto LoadFromCreate(CreateMediaItemDto createMediaItem, UpdateMediaItemDto existingItem)
        {
            existingItem.Title = createMediaItem.Title;
            existingItem.Description = createMediaItem.Description;
            existingItem.MediaType = createMediaItem.MediaType;
            existingItem.LibraryId = createMediaItem.LibraryId;
            existingItem.ThumbnailPath = createMediaItem.ThumbnailPath;
            return existingItem;
        }

    }
}
