using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace Medias.Data.Configurations
{
    public class TelevisionEpisodeConfiguration : IEntityTypeConfiguration<TelevisionEpisode>
    {
        public void Configure(EntityTypeBuilder<TelevisionEpisode> builder)
        {
            builder.ToTable("TelevisionEpisodes");

            builder.HasKey(e => e.EpisodeId);

            builder.Property(e => e.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Director)
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .HasMaxLength(2000);

            builder.Property(e => e.Rating)
                .HasPrecision(3, 1);

            builder.HasIndex(e => e.SeasonId);

            builder.HasIndex(e => new
            {
                e.SeasonId,
                e.EpisodeNumber
            }).IsUnique();

            builder.HasOne(e => e.TelevisionSeason)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
