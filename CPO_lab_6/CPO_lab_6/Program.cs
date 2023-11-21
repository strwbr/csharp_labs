using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stationery[] stationery = null;
            StationeryService service = new StationeryService();
            int size = 2;
            string path = "folder.dat";

            //stationery = service.InputAllData<Folder>(size);
            //service.SaveToFile(stationery, path);
            //Console.WriteLine("Saving to file successfully!");

            Stationery[] readStationeries = service.LoadFromFile<Folder>(path);
            service.PrintData<Folder>(readStationeries);
            Console.ReadKey(true);
        }
    }
}
