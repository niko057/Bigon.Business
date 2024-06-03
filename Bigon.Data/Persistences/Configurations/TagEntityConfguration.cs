using Bigon.Data.Persistences.Configurations;
using Bigon.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistences.Configurations
{
    public class TagEntityConfguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("int");

            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();

            builder.ConfigureAsAuditable();

            builder.ToTable("Tags");
        }
    }
}
