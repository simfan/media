using Medias.Integrations.Barcode;
using Medias.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers;

[ApiController]
[Route("api/barcode-test")]
/*public class BarcodeTestController(
    IBarcodeLookupService barcodeLookupService) : ControllerBase*/
public class BarcodeTestController : ControllerBase
{
    private readonly IMediaIdentificationService _mediaIdentificationService;

    public BarcodeTestController(IMediaIdentificationService mediaIdentificationService)
    {
        _mediaIdentificationService = mediaIdentificationService;
    }
    [HttpGet("{barcode}")]
    public async Task<IActionResult> Lookup(
        string barcode,
        CancellationToken cancellationToken)
    {
        /*var result = await barcodeLookupService.LookupAsync(
            barcode,
            cancellationToken);
        */
        string hello = "Hello";

        var result = await _mediaIdentificationService.IdentifyMediaItemByBarcode(barcode, cancellationToken);

        return Ok(result);
    }
}