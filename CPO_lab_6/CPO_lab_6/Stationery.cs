using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal abstract class Stationery
    {
        public string Company { get; set; }
        public float Price { get; set; }

        public Stationery()
        {
            Company = string.Empty;
            Price = 0.0f;
        }

        public Stationery(string company, float price)
        {
            Company = company;
            Price = price;
        }

        public virtual void WriteToFile(BinaryWriter writer)
        {
            writer.Write(Company);
            writer.Write(Price);
        }

        public virtual bool ReadFromFile(BinaryReader reader)
        {
            Company = reader.ReadString();
            Price = reader.ReadSingle();
            return true;
        }

        public override string ToString()
        {
            string format = $"| {{0,-20}} | {{1,-10}} |";
            return string.Format(format, Company, Price);
        }

        public virtual void Print()
        {
            string format = $"| {{1,-20}} | {{2,-10}} |";
            Console.WriteLine(format, "Фирма-производитель", "Цена");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(ToString());
            Console.WriteLine("---------------------------------------------------------------");
        }

        public virtual void ReadFromConsole()
        {
            Console.Write("Фирма-производитель: ");
            Company = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Цена: ");
                success = float.TryParse(Console.ReadLine(), out float price);
                if (success)
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public virtual void ReadFromConsoleForEdit()
        {
            Console.Write("Фирма-производитель: ");
            Company = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                Console.Write("Цена: ");
                string tempPrice = Console.ReadLine();
                float price = tempPrice.Equals("-") ? -1 : 0;
                success = price == -1 || float.TryParse(tempPrice, out price);
                if (success)
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
        }

        public abstract void Edit();
        //{
        //    Stationery temp = new Stationery();
        //    temp.ReadFromConsoleForEdit();
        //    Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
        //    Price = (temp.Price != -1) ? temp.Price : Price;
        //}
    }
}
