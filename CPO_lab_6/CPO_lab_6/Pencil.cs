using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Pencil : Stationery
    {
        public string Hardness { get; set; } // Твердость
        public string Color { get; set; } // Цвет
        public string Kind { get; set; } // Вид (акварельный, графитовый и тд)

        public Pencil() : base()
        {
            Hardness = Color = Kind = string.Empty;
        }

        public Pencil(string company, float price, string hardness, string color, string kind) : base(company, price)
        {
            Hardness = hardness;
            Color = color;
            Kind = kind;
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            writer.Write('P');
            base.WriteToFile(writer);
            writer.Write(Hardness);
            writer.Write(Color);
            writer.Write(Kind);
        }

        public override bool ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            Hardness = reader.ReadString();
            Color = reader.ReadString();
            Kind = reader.ReadString();
            return true;
        }

        public override string ToString()
        {
            string format = $" {{0,-15}} | {{1,-15}} | {{2,-15}} |";
            return base.ToString() + string.Format(format, Hardness, Color, Kind);
        }

        public override void Print()
        {            
            TableHeader();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(ToString());
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        }

        public override string TableHeader()
        {
            string format = $"| {{0,-20}} | {{1,-10}} | {{2,-15}} | {{3,-15}} | {{4,-15}} |";
            return string.Format(format, "Фирма-производитель", "Цена", "Твердость", "Цвет", "Вид");
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();

            Console.Write("Твердость: ");
            Hardness = Console.ReadLine();
            Console.Write("Цвет: ");
            Color = Console.ReadLine();
            Console.Write("Вид: ");
            Kind = Console.ReadLine();
        }

        public override void ReadFromConsoleForEdit()
        {
            base.ReadFromConsoleForEdit();

            Console.Write("Твердость грифеля: ");
            Hardness = Console.ReadLine();
            Console.Write("Цвет грифеля: ");
            Color = Console.ReadLine();
            Console.Write("Вид: ");
            Kind = Console.ReadLine();
        }

        public override void Edit()
        {
            Pencil temp = new Pencil();
            temp.ReadFromConsoleForEdit();

            Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
            Price = (temp.Price != -1) ? temp.Price : Price;
            Hardness = (!temp.Hardness.Equals("-")) ? temp.Hardness : Hardness;
            Color = (!temp.Color.Equals("-")) ? temp.Color : Color;
            Kind = (!temp.Kind.Equals("-")) ? temp.Kind : Kind;
        }
    }
}
