using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Folder : Stationery
    {
        public int Capacity { get; set; } // Вместимость (Кол-во листов)
        public string Mechanism { get; set; } // Механизм (кольца и тд)
        public string CoverColor { get; set; } // Цвет обложки

        public Folder(string company, float price, int capacity, string mechanism, string coverColor): base(company, price)
        {
            Capacity = capacity;
            Mechanism = mechanism;
            CoverColor = coverColor;
        }
    }
}
