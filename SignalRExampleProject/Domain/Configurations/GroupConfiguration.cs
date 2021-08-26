using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Domain.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.HasMany(x => x.Messages)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId);

        }
    }
}
