using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medias.Data.Entities;

namespace Medias.Data.Configurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            //Table Name
            builder.ToTable("Collections");

            //Primary Key
            builder.HasKey(x => x.CollectionId);

            //Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            //Indexes
            builder.HasIndex(x => x.Name).IsUnique();


        }
    }
}
