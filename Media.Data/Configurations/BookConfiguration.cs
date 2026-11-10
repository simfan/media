using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Medias.Data.Configurations
{
    public class BookDetailConfiguration : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            //Table Name
            builder.ToTable("Books");

            //Primary Key
            builder.HasKey(b => b.MediaItemId);

            //Properties
            builder.Property(b => b.Pages)
                .IsRequired();
            builder.Property(b => b.Genre)
                .HasMaxLength(100);
            builder.Property(b => b.Author)
                .HasMaxLength(200);
            builder.Property(b => b.Edition)
                .HasMaxLength(100);
            builder.Property(b => b.BookFormat)
                .HasMaxLength(50);
            builder.Property(b => b.TimeToRead);
            builder.Property(b => b.ISBN)
                .HasMaxLength(20);
            builder.Property(b => b.OpenLibraryId)
                .HasMaxLength(50);

            builder.HasIndex(b => b.Author);    
            builder.HasIndex(b => b.OpenLibraryId);
            builder.HasIndex(b => b.ISBN)
                .IsUnique();

            //Relationships
            builder.HasOne(b => b.MediaItem)
                .WithOne(m => m.BookDetail)
                .HasForeignKey<BookDetail>(b => b.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
