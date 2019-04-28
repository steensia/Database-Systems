using System;
using System.Collections.Generic;

namespace LibraryWebServer.Models
{
    public partial class Titles
    {
        public Titles()
        {
            Inventory = new HashSet<Inventory>();
        }

        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
