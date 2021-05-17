using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace les7
{
    public partial class Provides
    {
        public int Piece { get; set; }
        public string Provider { get; set; }
        public int Price { get; set; }

        public virtual Pieces PieceNavigation { get; set; }
        public virtual Providers ProviderNavigation { get; set; }
    }
}
