using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Domain.Configurations
{
    public class GroupMessageConfiguration : IEntityTypeConfiguration<GroupMessage>
    {
        public void Configure(EntityTypeBuilder<GroupMessage> builder)
        {
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.SenderId).IsRequired();
        }
    }
}
