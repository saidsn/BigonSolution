using Bigon.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {

            builder.Property(s => s.Id).UseIdentityColumn(1, 1);
            builder.Property(s => s.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(s => s.ShortName).HasColumnType("varchar").HasMaxLength(5).IsRequired();
            builder.ConfigureAsAuditable();


            builder.HasKey(s => s.Id);
            builder.ToTable("Sizes");
        }
    }
}
