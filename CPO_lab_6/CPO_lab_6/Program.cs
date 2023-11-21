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
            const string PATH = "data.dat";
            const int SIZE = 1;

            StationeryService service = new StationeryService();

            Console.WriteLine("--> Скоросшиватели:");
            Stationery[] folders = service.InputAllData<Folder>(SIZE);
            service.SaveToFile(folders, PATH);

            Console.WriteLine("\n--> Органайзеры:");
            Stationery[] organizers = service.InputAllData<Organizer>(SIZE);
            service.SaveToFile(organizers, PATH);

            Console.WriteLine("\n--> Карандаши:");
            Stationery[] pencils = service.InputAllData<Pencil>(SIZE);
            service.SaveToFile(pencils, PATH);

            Console.WriteLine("\n--> Тетради:");
            Stationery[] noteboks = service.InputAllData<Notebook>(SIZE);
            service.SaveToFile(noteboks, PATH);

            Stationery[] readData = service.LoadFromFile(PATH);
            service.PrintData(readData);

            Console.ReadKey(true);
        }


    }
}
