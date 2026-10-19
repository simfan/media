using Medias.Data.Contexts;
using Medias.Data.Entities;
using Medias.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Medias.Server.Repositories
{
    public class BarcodeProductRepository : IBarcodeProductRepository
    {
        private readonly MediaDbContext _context;

        public BarcodeProductRepository(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<BarcodeProduct?> GetBarcodeProductByBarcode(string barcode)
        {
            var barcodeProduct = await _context.BarcodeProducts
                .FirstOrDefaultAsync(bp => bp.Barcode == barcode);
            return barcodeProduct;
        }

        public async Task<BarcodeProduct> AddBarcodeProduct(BarcodeProduct barcodeProduct)
        {
            await _context.BarcodeProducts.AddAsync(barcodeProduct);
            await _context.SaveChangesAsync();
            return barcodeProduct;
        }

        public async Task<bool> UpdateBarcodeProduct(BarcodeProduct barcodeProduct)
        {
            _context.BarcodeProducts.Update(barcodeProduct);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteBarcodeProduct(string barcode)
        {
            var barcodeProduct = await _context.BarcodeProducts
                .FirstOrDefaultAsync(bp => bp.Barcode == barcode);
            if (barcodeProduct == null)
            {
                return false;
            }

            _context.BarcodeProducts.Remove(barcodeProduct);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
