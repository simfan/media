using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Medias.Client.Components;
using BlazorStrap;
using Blazor.Sonner.Extensions;
using Medias.Data.Contexts;
using Medias.Server.Repositories;
using Medias.Server.Services;
using Medias.Server.Services.Interfaces;
using Medias.Server.Settings;
using Microsoft.EntityFrameworkCore;
using Medias.Server.Repositories.Interfaces;
using Medias.Integrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazorStrap();
builder.Services.AddControllers().AddApplicationPart(typeof(Medias.Server.Controllers.MediaItemController).Assembly);
builder.Services.AddSonner();
builder.Services.AddDbContext<MediaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MediaDatabase")));
builder.Services.AddHttpClient<ITMDbService, TMDbService>();
builder.Services.AddHttpClient<IMusicBrainzService, MusicBrainzService>();
builder.Services.AddSingleton<IMovieBarcodeResolver, TemporaryMovieBarcodeResolver>();
builder.Services.Configure<TMDbSettings>(builder.Configuration.GetSection("TMDb"));
builder.Services.AddScoped<IMediaIdentificationService, MediaIdentificationService>();
builder.Services.AddScoped<IMediaItemService, MediaItemService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IBarcodeProductRepository, BarcodeProductRepository>();
builder.Services.AddScoped<IMediaItemRepository, MediaItemRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
//builder.Services.AddScoped<IMediaItemService, MediaItemApiClient>();
builder.Services.AddScoped(sp => new HttpClient
{
    //BaseAddress = new Uri("https://localhost:7294/")
    BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"] ?? sp.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>().BaseUri)
});
builder.Services.AddMediaIntegrations(builder.Configuration);
var dbPath = Path.GetFullPath(
    Path.Combine(builder.Environment.ContentRootPath, "..", "Media.Server", "Data", "media.db"));
Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

builder.Services.AddDbContext<MediaDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));
var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
if (app.Configuration.GetValue<bool>("Hosting:UseHttpsRedirection"))
    app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    /*var dbPath = Path.GetFullPath(
    Path.Combine(builder.Environment.ContentRootPath, "..", "Medias.Server", "Data", "media.db"));
    Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

    builder.Services.AddDbContext<MediaDbContext>(options =>
        options.UseSqlite($"Data Source={dbPath}"));*/
       //Directory.CreateDirectory("Data");
    var db = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
    db.Database.Migrate();
    app.Logger.LogInformation("Using database: {Path}", db.Database.GetDbConnection().DataSource);
}
    

app.Run();
