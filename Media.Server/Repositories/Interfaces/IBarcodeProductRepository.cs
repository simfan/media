using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medias.Server.Repositories.Interfaces
{
    public interface IBarcodeProductRepository
    {
        Task<BarcodeProduct?> GetBarcodeProductByBarcode(string barcode);
        Task<BarcodeProduct> AddBarcodeProduct(BarcodeProduct barcodeProduct);
        Task<bool> UpdateBarcodeProduct(BarcodeProduct barcodeProduct);
        Task<bool> DeleteBarcodeProduct(string barcode);
        
    }
}
