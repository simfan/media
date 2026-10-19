using System.Net;
using System.Net.Http.Json;
using Medias.Integrations.Barcode.UpcItemDb.Models;

namespace Medias.Integrations.Barcode.UpcItemDb;

public class UpcItemDbClient(HttpClient httpClient)
{
    public async Task<UpcItemDbLookupResponse> LookupAsync(
        string barcode,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            return new UpcItemDbLookupResponse
            {
                Status = UpcItemDbLookupStatus.InvalidBarcode
            };
        }

        var response = await httpClient.GetAsync(
            $"lookup?upc={Uri.EscapeDataString(barcode)}",
            cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return new UpcItemDbLookupResponse
            {
                Status = UpcItemDbLookupStatus.NotFound
            };
        }

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            return new UpcItemDbLookupResponse
            {
                Status = UpcItemDbLookupStatus.RateLimited
            };
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return new UpcItemDbLookupResponse
            {
                Status = UpcItemDbLookupStatus.InvalidBarcode
            };
        }

        if (!response.IsSuccessStatusCode)
        {
            return new UpcItemDbLookupResponse
            {
                Status = UpcItemDbLookupStatus.ProviderUnavailable
            };
        }

        var result = await response.Content.ReadFromJsonAsync<UpcItemDbResponse>(
            cancellationToken);

        var item = result?.Items.FirstOrDefault();

        return new UpcItemDbLookupResponse
        {
            Status = item is null
                ? UpcItemDbLookupStatus.NotFound
                : UpcItemDbLookupStatus.Found,
            Item = item
        };
    }
}