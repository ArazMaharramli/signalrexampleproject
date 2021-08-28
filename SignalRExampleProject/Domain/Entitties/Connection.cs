namespace SignalRExampleProject.Domain.Entitties
{
    public class Connection
    {
        public string ConnectionID { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
