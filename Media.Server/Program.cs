using Medias.Data.Contexts;
using Medias.Integrations;
using Medias.Server.Repositories;
using Medias.Server.Repositories.Interfaces;
using Medias.Server.Services;
using Medias.Server.Services.Interfaces;
using Medias.Server.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapiSystem.IO.InvalidDataException: 'Failed to load configuration from file 'C:\Users\chris\source\repos\Media\Media.Server\appsettings.json'.'
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MediaDbContext>(options =>options.UseSqlite(
    builder.Configuration.GetConnectionString("MediaDatabase")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("https://localhost:YOUR_CLIENT_PORT")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddHttpClient<ITMDbService, TMDbService>();
builder.Services.AddHttpClient<IMusicBrainzService, MusicBrainzService>();
builder.Services.AddSingleton<IMovieBarcodeResolver, TemporaryMovieBarcodeResolver>();

//Services
builder.Services.AddScoped<IMediaIdentificationService, MediaIdentificationService>();
builder.Services.AddScoped<IMediaItemService, MediaItemService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

//Repositories
builder.Services.AddScoped<IBarcodeProductRepository, BarcodeProductRepository>();
builder.Services.AddScoped<IMediaItemRepository, MediaItemRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddMediaIntegrations(builder.Configuration);

builder.Services.Configure<TMDbSettings>(
    builder.Configuration.GetSection("TMDb"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
