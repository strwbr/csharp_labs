using System;
using System.IO;

namespace CPO_lab_7
{
    internal class Notebook : Stationery
    {
        public int PagesNum { get; set; } // Кол-во страниц
        public string PaperType { get; set; } // Линия, клетка и тд
        public string Format { get; set; } // А4, А5 и тд

        public Notebook() : base()
        {
            PagesNum = 0;
            PaperType = Format = string.Empty;
        }

        public Notebook(string company, float price, int pagesNum, string paperType, string format) : base(company, price)
        {
            PagesNum = pagesNum;
            PaperType = paperType;
            Format = format;
        }

        //костыли - объяснение в Pencil
        public string GetCompany()
        {
            return Company;
        }

        public float GetPrice()
        {
            return Price;
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            writer.Write('N');
            base.WriteToFile(writer);
            writer.Write(PagesNum);
            writer.Write(PaperType);
            writer.Write(Format);
        }

        // TODO ну и хрень, добавить проверку мб (иначе я вообще хз почему тут bool)
        public override bool ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            PagesNum = reader.ReadInt32();
            PaperType = reader.ReadString();
            Format = reader.ReadString();

            return true;
        }

        public override string ToString()
        {
            string format = $" {{0,-15}} | {{1,-15}} | {{2,-15}} |";
            return base.ToString() + string.Format(format, PagesNum, PaperType, Format);
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
            return string.Format(format, "Фирма-производитель", "Цена", "Кол-во страниц", "Бумага", "Формат");
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();

            Console.Write("Тип бумаги: ");
            PaperType = Console.ReadLine();
            Console.Write("Формат: ");
            Format = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Кол-во страниц: ");
                success = int.TryParse(Console.ReadLine(), out int temp);
                if (success)
                {
                    PagesNum = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public override void ReadFromConsoleForEdit()
        {
            base.ReadFromConsoleForEdit();

            Console.Write("Тип бумаги: ");
            PaperType = Console.ReadLine();
            Console.Write("Формат: ");
            Format = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Кол-во страниц: ");
                string readStr = Console.ReadLine();
                int temp = readStr.Equals("-") ? -1 : 0;
                success = temp == -1 || int.TryParse(readStr, out temp);
                if (success)
                {
                    PagesNum = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public override void Edit()
        {
            Notebook temp = new Notebook();
            temp.ReadFromConsoleForEdit();

            Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
            Price = (temp.Price != -1) ? temp.Price : Price;
            PagesNum = (temp.PagesNum != -1) ? temp.PagesNum : PagesNum;
            PaperType = (!temp.PaperType.Equals("-")) ? temp.PaperType : PaperType;
            Format = (!temp.Format.Equals("-")) ? temp.Format : Format;
        }
    }
}
