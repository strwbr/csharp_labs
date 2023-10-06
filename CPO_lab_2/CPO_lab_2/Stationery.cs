using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_2
{
    class Stationery
    {
        public string Type { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }

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
        public void WriteToFile(StreamWriter writer)
        {
            writer.Write(Type + '|');
            writer.Write(Company + '|');
            writer.Write(Price.ToString() + '\n');
        }

        // Считывание объекта с файла

        public bool ReadFromFile(StreamReader reader)
        {
            string line = reader.ReadLine();
            // если считанная строка пустая
            if(string.IsNullOrEmpty(line))
                return false;
            
            string[] data = line.Split('|');
            // если отсутствует значения для одного из полей класса
            if(data.Length != 3)
                return false;

            Type = data[0].Trim();
            Company = data[1].Trim();

            // если в качестве цены указана строка
            if (!float.TryParse(data[2].Trim(), out float price))
                return false;
            Price = price;
            return true;
        }
    }
}
