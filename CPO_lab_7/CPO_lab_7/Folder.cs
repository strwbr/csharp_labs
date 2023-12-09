using System;
using System.IO;

namespace CPO_lab_7
{
    internal class Folder : Stationery
    {
        public int Capacity { get; set; } // Вместимость (Кол-во листов)
        public string Mechanism { get; set; } // Механизм (кольца и тд)
        public string CoverColor { get; set; } // Цвет обложки

        public Folder() : base()
        {
            Capacity = 0;
            Mechanism = CoverColor = string.Empty;
        }

        public Folder(string company, float price, int capacity, string mechanism, string coverColor) : base(company, price)
        {
            Capacity = capacity;
            Mechanism = mechanism;
            CoverColor = coverColor;
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            writer.Write('F');
            base.WriteToFile(writer);
            writer.Write(Capacity);
            writer.Write(Mechanism);
            writer.Write(CoverColor);
        }

        public override bool ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            Capacity = reader.ReadInt32();
            Mechanism = reader.ReadString();
            CoverColor = reader.ReadString();
            return true;
        }

        public override string ToString()
        {
            string format = $" {{0,-15}} | {{1,-15}} | {{2,-15}} |";
            return base.ToString() + string.Format(format, Capacity, Mechanism, CoverColor);
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
            return string.Format(format, "Фирма-производитель", "Цена", "Вместимость", "Механизм", "Цвет");
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();

            Console.Write("Механизм: ");
            Mechanism = Console.ReadLine();
            Console.Write("Цвет обложки: ");
            CoverColor = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Вместимость: ");
                success = int.TryParse(Console.ReadLine(), out int temp);
                if (success)
                {
                    Capacity = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public override void ReadFromConsoleForEdit()
        {
            base.ReadFromConsoleForEdit();

            Console.Write("Механизм: ");
            Mechanism = Console.ReadLine();
            Console.Write("Цвет обложки: ");
            CoverColor = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Вместимость: ");
                string readStr = Console.ReadLine();
                int temp = readStr.Equals("-") ? -1 : 0;
                success = temp == -1 || int.TryParse(readStr, out temp);
                if (success)
                {
                    Capacity = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public override void Edit()
        {
            Folder temp = new Folder();
            temp.ReadFromConsoleForEdit();

            Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
            Price = (temp.Price != -1) ? temp.Price : Price;
            Capacity = (temp.Capacity != -1) ? temp.Capacity : Capacity;
            Mechanism = (!temp.Mechanism.Equals("-")) ? temp.Mechanism : Mechanism;
            CoverColor = (!temp.CoverColor.Equals("-")) ? temp.CoverColor : CoverColor;
        }
    }
}
