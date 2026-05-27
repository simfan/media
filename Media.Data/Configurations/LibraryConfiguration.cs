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
        builder.HasKey(x => x.Id);

        //Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Path)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.LibraryType)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        //Indexes
        builder.HasIndex(x => x.Path);
    }
}