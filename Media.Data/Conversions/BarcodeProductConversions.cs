using System;
using System.Collections.Generic;
using System.Text;
using Medias.Data.Entities;
using Medias.Shared.DTOs;

namespace Medias.Data.Conversions
{
    public static class BarcodeProductConversions
    {
        public static BarcodeProductDTO ToBarcodeProductDTO(this BarcodeProduct entity)
        {
            var barcodeProductDTO =  new BarcodeProductDTO
            {
                Id = entity.Id,
                Barcode = entity.Barcode,
                Title = entity.Title,
                NormalizedTitle = entity.Title,
                Description = entity.Description,
                Brand = entity.Brand,
                //Category = entity.Category,
                ImageUrl = entity.ImageUrl
            };
            barcodeProductDTO.TitleNormalization(entity.Title);
            barcodeProductDTO.CategoryNormalization(entity.Category);
            return barcodeProductDTO;
        }

        public static BarcodeProduct ToBarcodeProduct(this BarcodeProductDTO dto)
        {
            return new BarcodeProduct
            {
                Id = dto.Id,
                Barcode = dto.Barcode,
                Title = dto.Title,
                Description = dto.Description,
                Brand = dto.Brand,
                Category = dto.Category,
                ImageUrl = dto.ImageUrl
            };
        }
    }
}
