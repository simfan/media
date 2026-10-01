using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Configurations
{
    public class TelevisionShowConfiguration : IEntityTypeConfiguration<TelevisionShowDetail>
    {
        public void Configure(EntityTypeBuilder<TelevisionShowDetail> builder)
        {
            //Table Name
            builder.ToTable("TelevisionShowDetails");

            //Primary Key
            builder.HasKey(tv => tv.MediaItemId);

            //Properties
            builder.Property(tv => tv.CreatedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(tv => tv.Studio)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(tv => tv.Genre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(tv => tv.Status)
                .HasMaxLength(50);

            builder.Property(tv => tv.Rating)
                .HasPrecision(3, 1);

            builder.Property(tv => tv.ImdbId)
                .HasMaxLength(20);

            builder.Property(tv => tv.SeasonCount)
                .IsRequired();

            //Indexes

            builder.HasIndex(tv => tv.CreatedBy);

            builder.HasIndex(tv => tv.Studio);

            builder.HasIndex(tv => tv.Genre);

            builder.HasIndex(tv => tv.TmdbTvId);

            //Relationships

            builder.HasOne(tv => tv.MediaItem)
                .WithOne(mi => mi.TelevisionShowDetail)
                .HasForeignKey<TelevisionShowDetail>(tv => tv.MediaItemId);
        }
    }
}
