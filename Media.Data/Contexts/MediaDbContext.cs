using System;
using System.Collections.Generic;
using System.Text;
using Media.Data;
//using Media.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Media.Data.Contexts
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
        {
        }
    }
}
