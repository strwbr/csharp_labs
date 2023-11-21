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
        public Stationery[] LoadFromFile<T>(string path) where T : Stationery, new()
        {
            // Проверка файла на пустоту
            if (IsFileEmpty(path))
                return null;

            List<Stationery> list = new List<Stationery>();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            // Пока не конец файла
            while (reader.PeekChar() > -1)
            {
                Stationery temp = new T();
                if (temp.ReadFromFile(reader))
                    list.Add(temp);
            }
            reader.Close();
            return list.ToArray();
        }

        // Вывод массива данных в виде таблицы
        public void PrintData<T>(Stationery[] stationeries) where T : Stationery, new()
        {
            string format = "| {0,-5} ";
            Console.WriteLine(string.Format(format, "№") + stationeries[0].TableHeader());
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < stationeries.Length; i++)
            {
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
                Console.WriteLine($"Товар {i + 1}");
                stationeries[i] = new T();
                stationeries[i].ReadFromConsole();
            }
            return stationeries;
        }

        private bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }
    }
}
