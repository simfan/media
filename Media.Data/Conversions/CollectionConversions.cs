using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using Medias.Data.Entities;
using Medias.Shared.DTOs;
using Medias.Shared.Enums;

namespace Medias.Data.Conversions
{
    public static class CollectionConversions
    {
        public static Collection ToCollection(this CollectionDto dto)
        {
            return new Collection
            {
                CollectionId = dto.CollectionId,
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate =dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };
        }

        public static Collection CreateDtoToCollection(this CreateCollectionDto dto)
        {

            return new Collection
            {
                CollectionId = 0,
                Name = dto.Name,
                Description = dto?.Description,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }

        public static Collection UpdateDtoToCollection(this UpdateCollectionDto dto, Collection existingEntity) 
        {
            
            existingEntity.Name = dto.Name;
            existingEntity.Description = dto?.Description;
            existingEntity.UpdatedDate = DateTime.Now;
            return existingEntity;
        }

        public static CollectionDto ToCollectionDto(this Collection entity)
        {
            CollectionDto dto = new CollectionDto();
            dto.CollectionId = entity.CollectionId;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.CreatedDate = entity.CreatedDate;
            dto.UpdatedDate = entity.UpdatedDate;
            //dto.Items.Clear();
            dto.Items = new List<MediaItemDto>();
            
            if (entity.MediaItemCollections?.Any() == true)
            {
                var mediaTypes = entity.MediaItemCollections.Select(mic => mic.MediaItem.MediaType)
                    .Distinct()
                    .ToList();
                if(mediaTypes.Count == 1)
                {
                    dto.CollectionMediaType = (CollectionMediaTypeValue)mediaTypes[0];
                }
                else
                {
                    dto.CollectionMediaType = CollectionMediaTypeValue.Mixed;
                }
                foreach(var mediaItemCollection in entity.MediaItemCollections)
                {
                    var mediaItem = mediaItemCollection.MediaItem;
                    var mediaItemDto = mediaItem.ToMediaItemDto();
                    dto.Items.Add(mediaItemDto);
                }
            }
            return dto;

        }
        
    }
}
