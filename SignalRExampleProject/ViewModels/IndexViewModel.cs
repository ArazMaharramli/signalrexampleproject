using System.Collections.Generic;

namespace SignalRExampleProject.ViewModels
{
    public class IndexViewModel
    {
        public List<(string Id, string UserName)> Users { get; set; }
    }
}
