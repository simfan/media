using Medias.Integrations.Barcode.UpcItemDb.Models;

namespace Medias.Integrations.Barcode.UpcItemDb;

public class UpcItemDbLookupResponse
{
    public UpcItemDbLookupStatus Status { get; init; }

    public UpcItemDbItem? Item { get; init; }
}