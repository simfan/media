using Medias.Integrations.Barcode.UpcItemDb.Models;

namespace Medias.Integrations.Barcode.UpcItemDb;

public class UpcItemDbBarcodeLookupService(
    UpcItemDbClient client) : IBarcodeLookupService
{
    public async Task<BarcodeLookupResult> LookupAsync(
    string barcode,
    CancellationToken cancellationToken = default)
    {
        var response = await client.LookupAsync(
            barcode,
            cancellationToken);

        return response.Status switch
        {
            UpcItemDbLookupStatus.Found when response.Item is not null
                => new BarcodeLookupResult
                {
                    Status = BarcodeLookupStatus.Found,
                    Barcode = barcode,
                    Title = response.Item.Title,
                    Description = response.Item.Description,
                    Brand = response.Item.Brand,
                    Category = response.Item.Category,
                    ImageUrl = response.Item.Images.FirstOrDefault()
                },

            UpcItemDbLookupStatus.NotFound
                => new BarcodeLookupResult
                {
                    Status = BarcodeLookupStatus.NotFound,
                    Barcode = barcode
                },

            UpcItemDbLookupStatus.InvalidBarcode
                => new BarcodeLookupResult
                {
                    Status = BarcodeLookupStatus.InvalidBarcode,
                    Barcode = barcode
                },

            UpcItemDbLookupStatus.RateLimited
                => new BarcodeLookupResult
                {
                    Status = BarcodeLookupStatus.RateLimited,
                    Barcode = barcode
                },

            _ => new BarcodeLookupResult
            {
                Status = BarcodeLookupStatus.ProviderUnavailable,
                Barcode = barcode
            }
        };
    }
}