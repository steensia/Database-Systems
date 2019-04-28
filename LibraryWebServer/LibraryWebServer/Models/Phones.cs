using System;
using System.Collections.Generic;

namespace LibraryWebServer.Models
{
    public partial class Phones
    {
        public uint CardNum { get; set; }
        public string Phone { get; set; }

        public virtual Patrons CardNumNavigation { get; set; }
    }
}
