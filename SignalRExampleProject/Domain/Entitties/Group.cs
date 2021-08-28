using System;
using System.Collections.Generic;

namespace SignalRExampleProject.Domain.Entitties
{
    public class Group
    {
        public Group()
        {
            Users = new HashSet<ApplicationUser>();
            Messages = new HashSet<GroupMessage>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<GroupMessage> Messages { get; set; }
    }
}
