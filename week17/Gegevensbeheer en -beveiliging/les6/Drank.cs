using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les6
{
    public class Drank
    {
        public int ID { get; set; }
        public string Merk { get; set; }

        public override string ToString()
        {
            return Merk;
        }
    }
}
