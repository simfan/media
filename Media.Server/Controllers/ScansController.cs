using Medias.Integrations.TMDb;
using Medias.Server.Services.Interfaces;
using Medias.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ScansController(
    IMovieBarcodeResolver movieBarcodeResolver,
    ITMDbService tmdbService) : ControllerBase
{
    [HttpGet("movies/{barcode}")]
    public async Task<ActionResult<MovieBarcodeLookupDto>> ResolveMovie(
        string barcode,
        CancellationToken cancellationToken)
    {
        var title = await movieBarcodeResolver.ResolveMovieTitleAsync(barcode, cancellationToken);

        if (title is null)
        {
            return NotFound(new { message = "No temporary movie mapping exists for this barcode." });
        }

        var tmdbResults = await tmdbService.SearchMoviesAsync(title);
        /*var results = tmdbResults?.Select(movie => new TMDbMovieSearchResponse
            {
                ID = movie.ImportId
                Title = movie.Title,
                Overview = movie.Description,
                Release_Date = movie.ReleaseDate,
                Poster_Path = movie.PosterPath
            })
            .ToList()
            ?? [];*/

        return Ok(new MovieBarcodeLookupDto
        {
            Barcode = barcode,
            SearchTitle = title,
            Results = tmdbResults.ToList()
        });
    }
}
