using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedestal.Catalog.Models;
using System;

namespace Pedestal.Catalog.Infrastructure.EntityConfigurations
{
    public class ModeldydooEntityTypeConfiguration : IEntityTypeConfiguration<Modeldydoo>
    {
        public void Configure(EntityTypeBuilder<Modeldydoo> builder)
        {
            builder.ToTable("Modeldydoo");

            builder.Property(ci => ci.Id)
                .UseHiLo("modeldydoo_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Description)
                .IsRequired(false)
                .HasMaxLength(256);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.FileUri)
                .IsRequired(true);

            builder.Property(ci => ci.UploadDateUtc)
                .IsRequired(true);

            builder.Property(ci => ci.UploaderId)
                .IsRequired(true);

            builder.Property(ci => ci.Tags)
                .IsRequired(true)
                .HasMaxLength(256);
        }
    }
}
