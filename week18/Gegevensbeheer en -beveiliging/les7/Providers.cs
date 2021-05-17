using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace les7
{
    public partial class Providers
    {
        public Providers()
        {
            Provides = new HashSet<Provides>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Provides> Provides { get; set; }
    }
}
