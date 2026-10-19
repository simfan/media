using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Integrations.Barcode;

public interface IBarcodeLookupService
{
    Task<BarcodeLookupResult?> LookupAsync(
        string barcode,
        CancellationToken cancellationToken = default);
}
