using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chatBot
{
    internal class Program
    {
        static List<string> DefaultAnswers = new List<string>();
        static List<string> DefaultPhrases = new List<string>();
        static Dictionary<string, List<string>> Patterns = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> PatternAnswers = new Dictionary<string, List<string>>();
        static string UserName = "";
        static Random Random = new Random();

        static void Main(string[] args)
        {
            //string path = "test.txt";

            ReadAllDatasets();
            UserName = StartChat();
            Console.WriteLine("Привет, " + UserName);
            string userInput = "";
            while (true)
            {
                userInput = Console.ReadLine().Trim();
                if(userInput.Equals("Пока"))
                {
                    Console.WriteLine("Спасибо за диалог!");
                    break;
                }
                //дальше логика
                Console.WriteLine(Answer(userInput)); //- метод за диалог основной
                //вопрос ли, по паттерну ли и тп
            }
            Console.ReadKey(true);
        }

        static void ReadAllDatasets()
        {
            DefaultAnswers = ReadDefaultFromFile("DefaultAnswers.txt");
            DefaultPhrases = ReadDefaultFromFile("DefaultPhrases.txt");
            Patterns = ReadPatternsFromFile("Patterns.txt");
            PatternAnswers = ReadPatternsFromFile("PatternAnswers.txt");
        }

        static Dictionary<string, List<string>> ReadPatternsFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            while (!reader.EndOfStream)
            {
                //ключ первый, значение второе
                string[] line = reader.ReadLine().Split('|');
                if (dictionary.ContainsKey(line[0]))
                {
                    dictionary[line[0]].Add(line[1]);
                }
                else dictionary.Add(line[0], new List<string> { line[1] });
                //Console.WriteLine(line);
            }
            reader.Close();
            return dictionary;
        }

        static List<string> ReadDefaultFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<string> list = new List<string>();
            while (!reader.EndOfStream)
            {
                list.Add(reader.ReadLine());
            }
            reader.Close();
            return list;
        }

        static string StartChat()
        {
            Console.WriteLine("Вас приветствует чат-бот 'Болтун'.\nВведите 'Пока' для выхода.\nВведите свое имя:");
            return Console.ReadLine().Trim();
        }

        static string Answer(string userInput)
        {
            string answer = "";
            if(userInput.Contains("?")) {
                answer = DefaultAnswers[Random.Next(DefaultAnswers.Count())];
            }
            else
            {
                answer = DefaultPhrases[Random.Next(DefaultPhrases.Count())];
            }

            userInput = String.Join(" ", userInput.ToLower().Split("[ {,|.}?]+".ToCharArray()));
            foreach(KeyValuePair<string, List<string>> entry in Patterns)
            {
                foreach(string str in entry.Value)
                {
                    Regex regex = new Regex(str);
                    if(regex.IsMatch(userInput))
                    {
                        answer = PatternAnswers[entry.Key][Random.Next(PatternAnswers[entry.Key].Count())];
                    }
                }
            }

            return answer;
        }
    }
}
