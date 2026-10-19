using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;

namespace Medias.Data.Configurations
{
    public class BarcodeProductConfiguration : IEntityTypeConfiguration<BarcodeProduct>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BarcodeProduct> builder)
        {
            //Table name
            builder.ToTable("BarcodeProducts");
            //Primary key
            builder.HasKey(b => b.Id);

            // Properties
            builder.Property(b => b.Barcode).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Title).HasMaxLength(200);
            builder.Property(b => b.Description).HasMaxLength(1000);
            builder.Property(b => b.Brand).HasMaxLength(100);
            builder.Property(b => b.Category).HasMaxLength(100);
            builder.Property(b => b.ImageUrl).HasMaxLength(500);

            // Indexes
            builder.HasIndex(x => x.Title);

        }
    }
}
