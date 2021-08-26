using System;

namespace SignalRExampleProject.Domain.Entitties
{
    public class GroupMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public string SenderId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
