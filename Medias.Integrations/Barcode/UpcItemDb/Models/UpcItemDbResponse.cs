namespace Medias.Integrations.Barcode.UpcItemDb.Models;

public class UpcItemDbResponse
{
    public string? Code { get; set; }

    public int Total { get; set; }

    public int Offset { get; set; }

    public List<UpcItemDbItem> Items { get; set; } = [];
}