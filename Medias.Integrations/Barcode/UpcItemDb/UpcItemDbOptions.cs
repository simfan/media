namespace Medias.Integrations.Barcode.UpcItemDb;

public class UpcItemDbOptions
{
    public const string SectionName = "Integrations:UpcItemDb";

    public string BaseUrl { get; set; } =
        "https://api.upcitemdb.com/prod/trial/";
}