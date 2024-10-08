﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_4
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

        // Вывод одного элемента в виде таблицы
        public void PrintOneStationery(Stationery stationery, int listNumber)
        {
            // Формат строки таблицы
            string format = $"| {{0,-5}} | {{1,-15}} | {{2,-20}} | {{3,-10}} |";

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(format, "", "Тип", "Фирма-производитель", "Цена");
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine(format, listNumber, stationery.Type, stationery.Company, stationery.Price);
            Console.WriteLine("---------------------------------------------------------------");
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

        // Считывание информации с консоли для редактирования товара
        private Stationery ReadDataFromConsoleForEdit()
        {
            Stationery temp = new Stationery();

            Console.Write("Тип: ");
            temp.Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            temp.Company = Console.ReadLine();

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
                    temp.Price = price;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
            return temp;
        }

        // Поиск по полю Тип товара
        public Stationery[] SearchByType(Stationery[] data, string query) => Array.FindAll(data, elem => elem.Type.ToLower() == query);

        // Поиск по полю Фирма-производитель
        public Stationery[] SearchByCompany(Stationery[] data, string query) => Array.FindAll(data, elem => elem.Company.ToLower() == query);

        // Поиск по полю Цена товара
        public Stationery[] SearchByPrice(Stationery[] data, float query) => Array.FindAll(data, elem => elem.Price == query);

        // Редактирование товара
        public Stationery EditStationery(Stationery data)
        {
            Stationery temp = ReadDataFromConsoleForEdit();
            data.Type = (!temp.Type.Equals("-")) ? temp.Type : data.Type;
            data.Company = (!temp.Company.Equals("-")) ? temp.Company : data.Company;
            data.Price = (temp.Price != -1) ? temp.Price : data.Price;
            return data;
        }

        // Сортировка по полю Тип товара
        public Stationery[] SortByType(Stationery[] data) => data.OrderBy(x => x.Type).ToArray();

        // Сортировка по полю Фирма-производитель
        public Stationery[] SortByCompany(Stationery[] data) => data.OrderBy(x => x.Company).ToArray();

        // Сортировка по полю Цена товара
        public Stationery[] SortByPrice(Stationery[] data) => data.OrderBy(x => x.Price).ToArray();

        // Проверка файла с путем path на пустоту
        private bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }
    }
}
