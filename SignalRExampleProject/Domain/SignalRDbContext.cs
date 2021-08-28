using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Domain
{
    public class SignalRDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SignalRDbContext(DbContextOptions<SignalRDbContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SignalRDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
