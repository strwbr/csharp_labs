using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CircularDoublyLinkedList<Stationery> list = new CircularDoublyLinkedList<Stationery>();
            List list = new List();
            list.Add(new Pencil("компания", 123, "твердый", "краснючи", "доброго подвида"));
            list.Add(new Pencil("ыаы", 345, "железный", "зелени", "доброго подвида"));
            list.Add(new Pencil("огогогог", 500, "рефлексирует", "сини", "злого подвида"));
            //list.Edit(0);
            list.Print();
            list.SearchByCompany("ыаы");
            //list.SearchByPrice(500);
            
            Console.ReadKey(true);
        }
    }
}
