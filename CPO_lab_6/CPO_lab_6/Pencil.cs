using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Pencil : Stationery
    {
        public string Hardness { get; set; } // Твердость грифеля
        public string Color { get; set;  } // Цвет грифеля
        public bool HasEraser { get; set;  } // Есть ли ластик

        public Pencil(string company, float price, string hardness, string color, bool hasEraser): base(company, price)
        {
            Hardness = hardness;
            Color = color;
            HasEraser = hasEraser;
        }
    }
}
