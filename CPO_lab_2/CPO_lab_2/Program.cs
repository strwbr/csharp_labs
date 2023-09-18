using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stationery stationery = null;
            string path = "data/data.txt";

            bool flag = true;
            while (flag)
            {
                Console.Clear();

                Console.WriteLine("Меню");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1 - Ввести данные");
                Console.WriteLine("2 - Сохранить данные в файл");
                Console.WriteLine("3 - Считать данные из файла");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("----------------------------");
                Console.Write("Введите команду: ");
                sbyte command = SByte.Parse(Console.ReadLine()); // sbyte = [-128;127], 1 байт

                //Console.Clear();
                Console.WriteLine("\n************************************\n");

                switch (command)
                {
                    case 0:
                        Console.WriteLine("Закрытие...");
                        flag = false;
                        break;
                    case 1:
                        stationery = InputData();
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        SaveToFile(stationery, path);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        LoadFromFile(path);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        static Stationery InputData()
        {
            Stationery stationery = new Stationery();

            Console.Write("Тип: ");
            stationery.Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            stationery.Company = Console.ReadLine();

            Console.Write("Цена: ");
            stationery.Price = float.Parse(Console.ReadLine());

            return stationery;
        }

        static void SaveToFile(Stationery stationery, string path)
        {
            if (stationery != null)
            {
                StreamWriter writer = new StreamWriter(path, true);
                stationery.WriteToFile(writer);
                writer.Close();
                Console.WriteLine("Данные добавлены в файл");
            } else
            {
                Console.WriteLine("Данные пустые");
            }
        }

        static void LoadFromFile(string path)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("{0, 20}    |{1, 30}    |{2, 10}", "Тип", "Фирма-производитель", "Цена");
            Console.WriteLine("-------------------------------------------------------------------------");

            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                Stationery stationery = new Stationery();
                stationery.ReadFromFile(reader);
                Console.WriteLine(stationery);
                Console.WriteLine("-------------------------------------------------------------------------");
            }

            reader.Close();
        }
    }
}
