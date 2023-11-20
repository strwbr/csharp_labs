using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Notebook : Stationery
    {
        public int PagesNum { get; set; } // Кол-во страниц
        public string PaperType { get; set; } // Линия, клетка и тд
        public string Format { get; set; } // А4, А5 и тд

        public Notebook(string company, float price, int pagesNum, string paperType, string format) : base(company, price)
        {
            PagesNum = pagesNum;
            PaperType = paperType;
            Format = format;
        }
    }
}
