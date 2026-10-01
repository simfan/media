using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;

namespace Medias.Data.Configurations;
public class MediaItemConfiguration : IEntityTypeConfiguration<MediaItem> 
{
    public void Configure(EntityTypeBuilder<MediaItem> builder)
    {
        //Table Name
        builder.ToTable("MediaItems");

        //Primary Key
        builder.HasKey(x => x.Id);

        //Properties
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.ThumbnailPath)
            .HasMaxLength(500);

        builder.Property(x => x.MediaType)
            .IsRequired();
        
        builder.Property(x => x.CreatedDate)
            .IsRequired();

        //Indexes
        builder.HasIndex(x => x.Title);

        builder.HasIndex(x => x.MediaType);

        builder.HasIndex(x => x.CreatedDate);

        //Relationships

        //MediaItem -> Library (Many-to-One)
        builder.HasOne(x => x.Library)
            .WithMany(x => x.MediaItems)
            .HasForeignKey(x => x.LibraryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.MediaFiles)
            .WithOne(x => x.MediaItem)
            .HasForeignKey(x => x.MediaItemId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}