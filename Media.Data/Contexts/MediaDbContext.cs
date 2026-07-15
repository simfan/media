using System;
using System.Collections.Generic;
using System.Text;
using Medias.Data;
using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Medias.Data.Contexts
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumTrack> AlbumTracks { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<MediaItemCollection> MediaItemCollections { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MusicDetail> MusicDetails { get; set; }
        public DbSet<TelevisionEpisode> TelevisionEpisodes { get; set; }
        public DbSet<TelevisionSeason> TelevisionSeasons { get; set; }
        public DbSet<TelevisionShowDetail> TelevisionShowDetails { get; set; }
        
        public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediaDbContext).Assembly);
        }
    }

}
