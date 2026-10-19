namespace Medias.Integrations.Barcode.UpcItemDb;

public enum UpcItemDbLookupStatus
{
    Found,
    NotFound,
    InvalidBarcode,
    RateLimited,
    ProviderUnavailable
}