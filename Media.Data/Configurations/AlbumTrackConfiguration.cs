using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Configurations
{
    public class AlbumTrackConfiguration : IEntityTypeConfiguration<AlbumTrack>
    {
        public void Configure(EntityTypeBuilder<AlbumTrack> builder)
        {
            builder.ToTable("AlbumTracks");

            builder.HasKey(x => x.TrackId);

            builder.Property(x => x.TrackNumber)
                .IsRequired();

            builder.Property(x => x.DiscNumber)
                .HasDefaultValue(1);

            builder.HasIndex(x => new 
            { 
                x.CollectionId, 
                x.MediaItemId 
            }).IsUnique();

            builder.HasIndex(x => new
            {
                x.CollectionId,
                x.DiscNumber,
                x.TrackNumber
            }).IsUnique();

            builder.HasOne(x => x.MusicDetail)
                .WithMany(md => md.AlbumTracks)
                .HasForeignKey(at => at.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(at => at.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(at => at.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

                
        }
    }
}
