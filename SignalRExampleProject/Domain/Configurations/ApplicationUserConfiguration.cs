using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Domain.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.Groups)
                .WithMany(x => x.Users);

            builder.HasMany(x => x.Connections)
                .WithOne(x => x.User);
        }
    }
}
