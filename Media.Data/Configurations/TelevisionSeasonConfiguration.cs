using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Configurations
{
    public class TelevisionSeasonConfiguration : IEntityTypeConfiguration<TelevisionSeason>
    {
        public void Configure(EntityTypeBuilder<TelevisionSeason> builder)
        {
            builder.ToTable("TelevisionSeasons");

            builder.HasKey(s => s.SeasonId);

            builder.Property(s => s.Name)
                .HasMaxLength(200);

            builder.Property(s => s.Description)
                .HasMaxLength(2000);

            builder.HasIndex(s => s.MediaItemId);

            builder.HasIndex(s => new
            {
                s.MediaItemId,
                s.SeasonNumber
            }).IsUnique();

            builder.HasOne(s => s.TelevisionShowDetail)
                .WithMany(tv => tv.Seasons)
                .HasForeignKey(s => s.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
