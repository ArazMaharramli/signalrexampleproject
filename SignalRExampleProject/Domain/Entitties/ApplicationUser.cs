using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SignalRExampleProject.Domain.Entitties
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Connection> Connections { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
