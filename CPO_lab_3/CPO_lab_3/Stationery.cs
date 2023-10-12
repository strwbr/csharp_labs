using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_3
{
    internal class Stationery
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
    }
}
