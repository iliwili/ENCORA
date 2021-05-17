using System;
using System.Collections.Generic;
using System.Text;

namespace les2
{
    class Order
    {
        public int OrderId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }
        public Client ClientId { get; set; }
        public Product ProductId { get; set; }
    }
}
