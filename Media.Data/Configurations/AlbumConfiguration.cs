using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Configurations
{
    public class AlbumConfiguration: IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder) {
            //Table Name
            builder.ToTable("Albums");

            //Primary Key
            builder.HasKey(x => x.CollectionId);

            //Properties
            builder.Property(x => x.Artist)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Studio)
                .HasMaxLength(200);

            builder.Property(x => x.Genre)
                .HasMaxLength(100);

            builder.Property(x => x.CoverArtPath)
                .HasMaxLength(500);

            builder.Property(x => x.MusicBrainzReleaseId)
                .HasMaxLength(36);

            builder.Property(x => x.MusicBrainzReleaseGroupId)
                .HasMaxLength(36);


            //Indexes
            builder.HasIndex(x => x.Artist);
            builder.HasIndex(x => x.Studio);
            builder.HasIndex(x => x.MusicBrainzReleaseId)
                .IsUnique();
            //Relationships
            builder.HasMany(a => a.Tracks)
                .WithOne(t => t.Album)
                .HasForeignKey(t => t.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
