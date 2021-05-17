using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace les7
{
    public partial class Pieces
    {
        public Pieces()
        {
            Provides = new HashSet<Provides>();
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Provides> Provides { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
