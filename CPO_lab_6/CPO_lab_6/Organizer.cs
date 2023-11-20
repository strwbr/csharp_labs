using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Organizer : Stationery
    {
        public int BranchesNum { get; set; } // Кол-во отделений
        public String Material { get; set; } // Материал
        public String Size { get; set; } // Размер

        public Organizer(string company, float price, int branchesNum, string material, string size) : base(company, price)
        {
            BranchesNum = branchesNum;
            Material = material;
            Size = size;
        }
    }
}
