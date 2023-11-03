using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_5
{
    // Класс "Канцелярский товар"
    internal class Stationery
    {
        public string Type { get; set; } // Тип товара
        public string Company { get; set; } // Фирма-производитель
        public float Price { get; set; } // Цена
        // Конструкторы
        public Stationery()
        {
            Type = string.Empty;
            Company = string.Empty;
            Price = 0.0f;
        }

        public Stationery(string type, string company, float price)
        {
            Type = type;
            Company = company;
            Price = price;
        }

        // Запись объекта в файл
        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(Type);
            writer.Write(Company);
            writer.Write(Price);
        }

        // Считывание объекта с файла
        public bool ReadFromFile(BinaryReader reader)
        {
            Type = reader.ReadString();
            Company = reader.ReadString();
            Price = reader.ReadSingle();
            return true;
        }

        public override string ToString()
        {
            // Формат строки
            string format = $"| {{0,-15}} | {{1,-20}} | {{2,-10}} |";
            return string.Format(format, Type, Company, Price);
        }

        public void Print()
        {
            string format = $"| {{0,-15}} | {{1,-20}} | {{2,-10}} |";
            Console.WriteLine(format, "Тип", "Фирма-производитель", "Цена");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(ToString());
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void ReadFromConsole()
        {
            Console.Write("Тип: ");
            Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            Company = Console.ReadLine();

            bool success = false; // флаг успешности ввода
            // Запрос ввода цены повторяется, пока пользователь не введет число
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

        private void ReadFromConsoleForEdit()
        {
            Console.Write("Тип: ");
            Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            Company = Console.ReadLine();

            bool success = false; // флаг успешности ввода
            // Запрос ввода цены повторяется, пока пользователь не введет число или -
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

        public void Edit()
        {
            Stationery temp = new Stationery();
            temp.ReadFromConsoleForEdit();
            Type = (!temp.Type.Equals("-")) ? temp.Type : Type;
            Company = (!temp.Company.Equals("-")) ? temp.Company : Company;
            Price = (temp.Price != -1) ? temp.Price : Price;
        }
    }
}
