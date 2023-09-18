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

        public void WriteToFile(StreamWriter writer)
        {
            writer.Write(this.Type + '|');
            writer.Write(this.Company + '|');
            writer.Write(this.Price.ToString() + '\n');
        }

        public void ReadFromFile(StreamReader reader)
        {
            string[] data = reader.ReadLine().Split('|');
            this.Type = data[0];
            this.Company = data[1];
            this.Price = float.Parse(data[2]);
        }

        // Отрефакторить для табличного вывода
        public override string ToString()
        {
            return String.Format("{0, 20}    |{1, 30}    |{2, 10}", Type, Company, Price);
            //return Type + " " + Company + " " + Price.ToString();
        }
    }
}
