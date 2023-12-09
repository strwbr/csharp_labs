using System;
using System.IO;

namespace CPO_lab_7
{
    internal class Organizer : Stationery
    {
        public int BranchesNum { get; set; } // Кол-во отделений
        public String Material { get; set; } // Материал
        public String Size { get; set; } // Размер

        public Organizer() : base()
        {
            BranchesNum = 0;
            Material = string.Empty;
            Size = string.Empty;
        }

        public Organizer(string company, float price, int branchesNum, string material, string size) : base(company, price)
        {
            BranchesNum = branchesNum;
            Material = material;
            Size = size;
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            writer.Write('O');
            base.WriteToFile(writer);
            writer.Write(BranchesNum);
            writer.Write(Material);
            writer.Write(Size);
        }

        public override bool ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            BranchesNum = reader.ReadInt32();
            Material = reader.ReadString();
            Size = reader.ReadString();
            return true;
        }

        public override string ToString()
        {
            string format = $" {{0,-18}} | {{1,-15}} | {{2,-15}} |";
            return base.ToString() + string.Format(format, BranchesNum, Material, Size);
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
            string format = $"| {{0,-20}} | {{1,-10}} | {{2,-18}} | {{3,-15}} | {{4,-15}} |";
            return string.Format(format, "Фирма-производитель", "Цена", "Кол-во отделений", "Материал", "Размер");
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();

            Console.Write("Материал: ");
            Material = Console.ReadLine();
            Console.Write("Размер: ");
            Size = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Кол-во отделений: ");
                success = int.TryParse(Console.ReadLine(), out int temp);
                if (success)
                {
                    BranchesNum = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }
        // НЕ ЗАБУДЬ поменять поле в которое записывается число!!!!
        public override void ReadFromConsoleForEdit()
        {
            base.ReadFromConsoleForEdit();

            Console.Write("Материал: ");
            Material = Console.ReadLine();
            Console.Write("Размер: ");
            Size = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Кол-во отделений: ");
                string readStr = Console.ReadLine();
                int temp = readStr.Equals("-") ? -1 : 0;
                success = temp == -1 || int.TryParse(readStr, out temp);
                if (success)
                {
                    BranchesNum = temp;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public override void Edit()
        {
            Organizer temp = new Organizer();
            temp.ReadFromConsoleForEdit();

            Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
            Price = (temp.Price != -1) ? temp.Price : Price;

            BranchesNum = (temp.BranchesNum != -1) ? temp.BranchesNum : BranchesNum;
            Material = (!temp.Material.Equals("-")) ? temp.Material : Material;
            Size = (!temp.Size.Equals("-")) ? temp.Size : Size;
        }
    }
}
