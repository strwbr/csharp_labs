using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class Node
    {
        public Stationery Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(Stationery stationery)
        {
            Data = stationery;
            Next = null;
            Previous = null;
        }
    }
}
