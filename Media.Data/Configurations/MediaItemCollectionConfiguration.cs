using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Configurations
{
    public class MediaItemCollectionConfiguration : IEntityTypeConfiguration<MediaItemCollection>
    {
        public void Configure(EntityTypeBuilder<MediaItemCollection> builder)
        {
            builder.ToTable("MediaItemCollections");

            builder.HasKey(x => new { x.MediaItemId, x.CollectionId});

            builder.HasOne(x => x.MediaItem)
                .WithMany(x => x.MediaItemCollections)
                .HasForeignKey(x => x.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Collection)
                .WithMany(x => x.MediaItemCollections)
                .HasForeignKey(x => x.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
