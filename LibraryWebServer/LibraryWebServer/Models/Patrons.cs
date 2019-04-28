using System;
using System.Collections.Generic;

namespace LibraryWebServer.Models
{
    public partial class Patrons
    {
        public Patrons()
        {
            CheckedOut = new HashSet<CheckedOut>();
            Phones = new HashSet<Phones>();
        }

        public uint CardNum { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CheckedOut> CheckedOut { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
