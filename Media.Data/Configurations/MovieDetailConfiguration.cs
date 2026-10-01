using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;

namespace Medias.Data.Configurations
{
    public class MovieDetailConfiguration : IEntityTypeConfiguration<MovieDetail>
    {
        public void Configure(EntityTypeBuilder<MovieDetail> builder)
        {
            //Table Name
            builder.ToTable("MovieDetails");

            //Primary Key
            builder.HasKey(md => md.MediaItemId);

            //Properties
            builder.Property(md => md.Director)
                .HasMaxLength(200);

            builder.Property(md => md.Studio)
                .HasMaxLength(200);

            builder.Property(md => md.Genre)
                .HasMaxLength(50);

            builder.Property(md => md.Runtime)
                .IsRequired();

            builder.Property(md => md.ReleaseDate)
                .IsRequired();
            //Indexes

            builder.HasIndex(md => md.Director);

            builder.HasIndex(md => md.Studio);

            builder.HasIndex(md => md.Genre);
            //Relationships
            builder.HasOne(md => md.MediaItem)
                   .WithOne(mi => mi.MovieDetail)
                   .HasForeignKey<MovieDetail>(md => md.MediaItemId);
        }
    }
}
