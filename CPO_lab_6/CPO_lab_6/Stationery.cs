using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal abstract class Stationery
    {
        public string Company { get; set; }
        public float Price { get; set; }

        public Stationery(string company, float price)
        {
            Company = company;
            Price = price;
        }
    }
}
