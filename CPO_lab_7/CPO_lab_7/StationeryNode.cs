using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class StationeryNode
    {
        public Stationery Data { get; set; }
        public StationeryNode Next { get; set; }
        public StationeryNode Previous { get; set; }

        public StationeryNode(Stationery stationery)
        {
            Data = stationery;
            Next = null;
            Previous = null;
        }
    }
}
