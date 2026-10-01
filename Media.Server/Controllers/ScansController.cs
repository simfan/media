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
        var results = tmdbResults?.Results
            .Select(movie => new TMDbMovieSearchRecord
            {
                ID = movie.ID,
                Title = movie.Title,
                Overview = movie.Overview,
                Release_Date = movie.Release_Date,
                Poster_Path = movie.Poster_Path
            })
            .ToList()
            ?? [];

        return Ok(new MovieBarcodeLookupDto
        {
            Barcode = barcode,
            SearchTitle = title,
            Results = results
        });
    }
}
