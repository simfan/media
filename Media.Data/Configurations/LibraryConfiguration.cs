using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Media.Data.Entities;

namespace Media.Data.Configurations;

public class LibraryConfiguration : IEntityTypeConfiguration<Library> 
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        //Table Name
        builder.ToTable("Libraries");

        //Primary Key
        builder.HasKey("Id");

        //Properties
        builder.Property("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property("Description")
            .HasMaxLength(500);

        builder.Property("Path")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property("LibraryType")
            .IsRequired();

        builder.Property("CreatedDate")
            .IsRequired();

        //Indexes
        builder.HasIndex(x => x.Path);
    }
}