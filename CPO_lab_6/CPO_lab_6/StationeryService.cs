using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
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
                char label = reader.ReadChar();
                Stationery temp = GetStationeryInstance(label);
                //Stationery temp = new T();
                if (temp.ReadFromFile(reader))
                    list.Add(temp);
            }
            reader.Close();
            return list.ToArray();
        }

        public Stationery GetStationeryInstance(char label)
        {
            switch (label)
            {
                case 'F': return new Folder();
                case 'O': return new Organizer();
                case 'P': return new Pencil();
                case 'N': return new Notebook();
            }
            return null;
        }

        // Вывод массива данных в виде таблицы
        public void PrintData(Stationery[] stationeries)
        {
            string format = $"| {{0,-5}} ";
            //Console.WriteLine(string.Format(format, "№") + stationeries[0].TableHeader());
            //Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < stationeries.Length; i++)
            {
                Console.WriteLine();
                
                Console.WriteLine(string.Format(format, "№") + stationeries[i].TableHeader());
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.Write(format, i + 1);
                Console.WriteLine(stationeries[i].ToString());
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
        }

        public Stationery[] InputAllData<T>(int size) where T : Stationery, new()
        {
            Stationery[] stationeries = new Stationery[size];
            for (int i = 0; i < stationeries.Length; i++)
            {
                Console.WriteLine($"\nТовар {i + 1}");
                stationeries[i] = new T();
                stationeries[i].ReadFromConsole();
            }
            return stationeries;
        }

        // Поиск по полю Фирма-производитель
        public Stationery[] SearchByCompany(Stationery[] data, string query) => Array.FindAll(data, elem => elem.Company.ToLower() == query);

        // Поиск по полю Цена товара
        public Stationery[] SearchByPrice(Stationery[] data, float query) => Array.FindAll(data, elem => elem.Price == query);

        // Сортировка по полю Фирма-производитель
        public Stationery[] SortByCompany(Stationery[] data) => data.OrderBy(x => x.Company).ToArray();

        // Сортировка по полю Цена товара
        public Stationery[] SortByPrice(Stationery[] data) => data.OrderBy(x => x.Price).ToArray();

        private bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }
    }
}
