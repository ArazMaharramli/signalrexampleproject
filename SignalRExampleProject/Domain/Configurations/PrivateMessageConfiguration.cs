using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Domain.Configurations
{
    public class PrivateMessageConfiguration : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.SenderId).IsRequired();
            builder.Property(x => x.ReceiverId).IsRequired();
        }
    }
}
