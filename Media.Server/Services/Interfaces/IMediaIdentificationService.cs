using Medias.Shared.DTOs;

namespace Medias.Server.Services.Interfaces
{
    public interface IMediaIdentificationService
    {
        Task<BarcodeProductDTO?> IdentifyMediaItemByBarcode(string barcode, CancellationToken cancellationToken);

    }
}
