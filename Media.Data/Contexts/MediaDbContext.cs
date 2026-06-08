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
        public DbSet<Library> Libraries { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
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
