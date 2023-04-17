using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace InfoVip.Models.Configurations
{
    partial class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
    {
        public void Configure(EntityTypeBuilder<ApiKey> entity)
        {
            entity.ToTable("apikey");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.apikey).HasColumnName("apikey");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ApiKey> entity);
    }
}
