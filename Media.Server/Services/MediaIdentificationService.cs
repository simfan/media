using Medias.Data.Entities;
using Medias.Server.Repositories;
using Medias.Shared.DTOs;
using Medias.Integrations.Barcode;
using Medias.Data.Conversions;
using Medias.Server.Repositories.Interfaces;
using Medias.Server.Services.Interfaces;

namespace Medias.Server.Services
{
    public class MediaIdentificationService : IMediaIdentificationService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediaItemRepository _mediaItemRepository;
        private readonly IBarcodeProductRepository _barcodeProductRepository;
        private readonly IBarcodeLookupService _barcodeLookupService;


        public MediaIdentificationService(IConfiguration configuration, IMediaItemRepository mediaItemRepository, IBarcodeProductRepository barcodeProductRepository, IBarcodeLookupService barcodeLookupService)
        {
            _configuration = configuration;
            _mediaItemRepository = mediaItemRepository;
            _barcodeProductRepository = barcodeProductRepository;
            _barcodeLookupService = barcodeLookupService;
        }

        public async Task<BarcodeProductDTO?> IdentifyMediaItemByBarcode(string barcode, CancellationToken cancellationToken)
        {
            var mediaItem = await _mediaItemRepository.GetMediaItemByBarcode(barcode);
            BarcodeProductDTO barcodeProductDTO = new BarcodeProductDTO();
            if (mediaItem != null)
            {
                barcodeProductDTO = mediaItem.ToBarcodeProductDTO();
                //return mediaItem;
                return barcodeProductDTO;
            }
            
            var barcodeProduct = await _barcodeProductRepository.GetBarcodeProductByBarcode(barcode);
            if (barcodeProduct != null)
            {
                barcodeProductDTO = barcodeProduct.ToBarcodeProductDTO();
                return barcodeProductDTO;
            }

            var barcodeLookupResult = await _barcodeLookupService.LookupAsync(barcode, cancellationToken);
            if (barcodeLookupResult.Status == BarcodeLookupStatus.Found)
            {
                
                var newBarcodeProduct = new BarcodeProduct
                {
                    Barcode = barcodeLookupResult.Barcode,
                    Title = barcodeLookupResult.Title,
                    Description = barcodeLookupResult.Description,
                    Brand = barcodeLookupResult.Brand,
                    Category = barcodeLookupResult.Category,
                    ImageUrl = barcodeLookupResult.ImageUrl
                };
                newBarcodeProduct = await _barcodeProductRepository.AddBarcodeProduct(newBarcodeProduct);
                barcodeProductDTO = new BarcodeProductDTO
                {
                    Id = 0,
                    Barcode = barcodeLookupResult.Barcode,
                    Title = barcodeLookupResult.Title,
                    //NormalizedTitle = barcodeLookupResult.Title?.ToLowerInvariant(),
                    Description = barcodeLookupResult.Description,
                    Brand = barcodeLookupResult.Brand,
                    //Category = barcodeLookupResult.Category,
                    ImageUrl = barcodeLookupResult.ImageUrl
                };
                barcodeProductDTO.TitleNormalization(barcodeProductDTO.Title);
                barcodeProductDTO.CategoryNormalization(barcodeLookupResult.Category);
                return barcodeProductDTO;
            }
            return null;
        }


    } 
}
