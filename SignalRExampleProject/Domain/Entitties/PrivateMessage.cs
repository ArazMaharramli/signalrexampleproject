using System;

namespace SignalRExampleProject.Domain.Entitties
{
    public class PrivateMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
