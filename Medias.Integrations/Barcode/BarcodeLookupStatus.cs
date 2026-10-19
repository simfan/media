namespace Medias.Integrations.Barcode;

public enum BarcodeLookupStatus
{
    Found,
    NotFound,
    InvalidBarcode,
    RateLimited,
    ProviderUnavailable
}