using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InfoVip.Models.Configurations
{
    public partial class apiportfolioIDsConfiguration : IEntityTypeConfiguration<apiportfolioIDs>
    {
        public void Configure(EntityTypeBuilder<apiportfolioIDs> entity)
        {
            entity.ToTable("apiportfolioIDs");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.coinid).HasColumnName("coinid");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<apiportfolioIDs> entity);
    }
}
