using Bigon.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(s => s.Id).UseIdentityColumn(1, 1);
            builder.Property(s => s.ParentId).HasColumnType("int");
            builder.Property(s => s.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.ConfigureAsAuditable();

            builder.HasOne<Category>()
                 .WithMany()
                 .HasForeignKey(c => c.ParentId)
                 .HasPrincipalKey(c => c.Id);


            builder.HasKey(s => s.Id);
            builder.ToTable("Categories");
        }
    }
}
