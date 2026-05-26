using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Media.Data.Entities;

namespace Media.Data.Configurations;


public class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile> 
{
    public void Configure(EntityTypeBuilder<MediaFile> builder)
    {
        //Table Name
        builder.ToTable("MediaFiles");

        //Primary Key
        builder.HasKey(x => x.Id);
        
        //Properties
        builder.Property(x => x.FileName)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.FileType)
            .IsRequired()
            .HasMaxLength(10);
        
        builder.Property(x => x.FilePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.FileSize)
            .IsRequired();

        builder.Property(x => x.Checksum)
            .HasMaxLength(64);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        //Indexes
        builder.HasIndex(x => x.FilePath);

        builder.HasIndex(x => x.Checksum);

        builder.HasIndex(x => x.MediaItemId);

        //Relationships

        //Media File => Media Item
        //builder.HasOne()
    }
}