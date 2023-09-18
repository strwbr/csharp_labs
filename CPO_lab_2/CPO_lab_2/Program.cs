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
            //Menu();

            string path = "data/data.txt";
            //StreamWriter writer = new StreamWriter(path, false);
            //writer.WriteLine("test data");
            //writer.Close();

            //StreamReader reader = new StreamReader(path);
            //string data = reader.ReadToEnd();
            //Console.WriteLine(data);
            //reader.Close();

            Stationery stationery = new Stationery("type1", "company1", 100.0f);

            StreamWriter writer = new StreamWriter(path, true);
            stationery.WriteToFile(writer);
            stationery.WriteToFile(writer);
            writer.Close();

            StreamReader reader = new StreamReader(path);
            Stationery stationery1 = new Stationery();
            stationery1.ReadFromFile(reader);
            reader.Close();



            Console.WriteLine("------OK!------");
            Console.ReadKey(true);
        }

        static void Menu()
        {
            sbyte command = -1; // sbyte = [-128;127], 1 байт
            while (command == -1)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("----------------");
                Console.WriteLine("1 - ...");
                Console.WriteLine("2 - ...");
                Console.WriteLine("3 - ...");
                Console.WriteLine("0 - Выход");
                command = SByte.Parse(Console.ReadLine());

                switch (command)
                {
                    case 0:
                        Console.WriteLine("Закрытие...");
                        break;
                    case 1:
                        Console.WriteLine("Вы выбрали раздел 1");
                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали раздел 2");
                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали раздел 3");
                        break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        command = -1;
                        break;
                }
            }
        }


    }
}
