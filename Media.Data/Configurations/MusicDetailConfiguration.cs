using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;

namespace Medias.Data.Configurations
{
    public class MusicDetailConfiguration : IEntityTypeConfiguration<MusicDetail>
    {
        public void Configure(EntityTypeBuilder<MusicDetail> builder)
        {
            //Table Name
            builder.ToTable("MusicDetails");

            builder.HasKey(md => md.MediaItemId);

            builder.Property(md => md.Artist)
                .HasMaxLength(200);

            builder.Property(md => md.Writer)
                .HasMaxLength(200);

            builder.Property(md => md.Studio)
                .HasMaxLength(200);

            builder.Property(md => md.Genre)
                .HasMaxLength(50);

            builder.Property(md => md.Runtime)
                .IsRequired();

            builder.Property(md => md.FirstReleased)
                .IsRequired();

            builder.HasIndex(md => md.Artist);

            builder.HasIndex(md => md.Writer);

            builder.HasIndex(md => md.Studio);
            builder.HasIndex(md => md.Genre);

            builder.HasOne(md => md.MediaItem)
                .WithOne(mi => mi.MusicDetail)
                .HasForeignKey<MusicDetail>(mi => mi.MediaItemId);




        }
    }
}
