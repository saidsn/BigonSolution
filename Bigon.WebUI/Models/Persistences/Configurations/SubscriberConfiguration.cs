using Bigon.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {

            builder.Property(s => s.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(s => s.Approved).HasColumnType("bit").IsRequired();
            builder.Property(s => s.ApprovedAt).HasColumnType("datetime");
            builder.Property(s => s.CreatedDate).HasColumnType("datetime").IsRequired();

            builder.HasKey(s => s.Email);
            builder.ToTable("Subscribers");
        }
    }
}
