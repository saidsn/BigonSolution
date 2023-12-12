using Bigon.WebUI.Models.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public static class ConfigurationHelper
    {

        public static EntityTypeBuilder<T> ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder)
            where T : AuditableEntity
        {
            builder.Property(s => s.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(s => s.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(s => s.LastModifiedBy).HasColumnType("int");
            builder.Property(s => s.LastModifiedAt).HasColumnType("datetime");
            builder.Property(s => s.DeletedBy).HasColumnType("int");
            builder.Property(s => s.DeletedAt).HasColumnType("datetime");
            return builder;
        }

    }
}
