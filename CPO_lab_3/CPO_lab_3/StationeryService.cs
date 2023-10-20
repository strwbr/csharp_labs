using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_3
{
    // Класс сервиса для работы с объектами типа Stationery
    internal class StationeryService
    {
        // Сохранение массива данных в файл с путем path
        public void SaveToFile(Stationery[] stationeries, string path)
        {
            // FileMode.Append - запись в конец файла. Если файл не существует, то он будет создан
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append));
            foreach (Stationery el in stationeries)
            {
                el.WriteToFile(writer);
            }
            writer.Close();
        }

        // Загрузка массива данных из файла с путем path
        public Stationery[] LoadFromFile(string path)
        {
            // Проверка файла на пустоту
            if (IsFileEmpty(path))
                return null;

            List<Stationery> list = new List<Stationery>();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            // Пока не конец файла
            while (reader.PeekChar() > -1)
            {
                Stationery temp = new Stationery();
                if (temp.ReadFromFile(reader))
                    list.Add(temp);
            }
            reader.Close();
            return list.ToArray();
        }

        // Вывод массива данных в виде таблицы
        public void PrintData(Stationery[] stationeries)
        {
            // Формат строки таблицы
            string format = $"| {{0,-5}} | {{1,-15}} | {{2,-20}} | {{3,-10}} |";

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(format, "", "Тип", "Фирма-производитель", "Цена");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < stationeries.Length; i++)
            {
                Console.WriteLine(format, i + 1, stationeries[i].Type, stationeries[i].Company, stationeries[i].Price);
                Console.WriteLine("---------------------------------------------------------------");
            }
        }

        // Ввод массива данных с консоли
        public Stationery[] InputAllData(int size)
        {
            Stationery[] stationeries = new Stationery[size];
            for (int i = 0; i < stationeries.Length; i++)
            {
                Console.WriteLine($"Товар {i + 1}");
                stationeries[i] = ReadDataFromConsole();
            }
            return stationeries;
        }

        // Считывание информации об одном объекте с консоли
        private Stationery ReadDataFromConsole()
        {
            Stationery temp = new Stationery();

            Console.Write("Тип: ");
            temp.Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            temp.Company = Console.ReadLine();

            bool success = false; // флаг успешности ввода
            // Запрос ввода цены повторяется, пока пользователь не введет число
            while (!success)
            {
                Console.Write("Цена: ");
                success = float.TryParse(Console.ReadLine(), out float price);
                if (success)
                {
                    temp.Price = price;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
            return temp;
        }

        // Поиск - заглушка
        public void Search()
        {
            Console.WriteLine("Вызван метод поиска: Search()");
        }

        // Редактирование - заглушка
        public void Edit()
        {
            Console.WriteLine("Вызван метод редактирования: Edit()");
        }

        // Сортировка - заглушка
        public void Sort()
        {
            Console.WriteLine("Вызван метод сортировки: Sort()");
        }

        // Проверка файла с путем path на пустоту
        private bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }
    }
}
