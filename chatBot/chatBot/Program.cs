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
        static Dictionary<string, List<string>> PatternPhrases = new Dictionary<string, List<string>>();
        static string UserName = "";
        static Random Random = new Random();

        static void Main(string[] args)
        {
            //string path = "test.txt";

            ReadAllDatasets();

            StartChat();

            string userInput;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"[{DateTime.Now:t}] Вы: ");
                userInput = Console.ReadLine().Trim();

                if (userInput.Equals("Пока"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[{DateTime.Now:t}] Бот: Было приятно с Вами, {UserName}, пообщаться. До свидания!");
                    break;
                }
                //дальше логика
                //вопрос ли, по паттерну ли и тп
                string botAnswer = Answer(userInput);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"[{DateTime.Now:t}] Бот: {botAnswer}");

            }
            Console.ReadKey(true);
        }

        static void ReadAllDatasets()
        {
            DefaultAnswers = ReadDefaultFromFile("DefaultAnswers.txt");
            DefaultPhrases = ReadDefaultFromFile("DefaultPhrases.txt");
            Patterns = ReadPatternsFromFile("Patterns.txt");
            PatternAnswers = ReadPatternsFromFile("PatternAnswers.txt");
            //добавить этот файл
            PatternPhrases = ReadPatternsFromFile("PatternPhrases.txt");
        }

        static Dictionary<string, List<string>> ReadPatternsFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            while (!reader.EndOfStream)
            {
                //ключ первый, значение второе
                string[] line = reader.ReadLine().ToLower().Split('|');
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

        static void StartChat()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[{DateTime.Now:t}] Бот: Вас приветствует чат-бот 'Болтун'.\nВведите 'Пока' для выхода.\nКак Вас зовут?");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now:t}] Вы: ");
            UserName = Console.ReadLine().Trim();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (UserName != null)
                Console.WriteLine($"[{DateTime.Now:t}] Бот: Привет, " + UserName);
            else
                Console.WriteLine($"[{DateTime.Now:t}] Бот: Привет!");
            //return Console.ReadLine().Trim();
        }

        static string Answer(string userInput)
        {
            // флаг что это вопрос
            // в отдельном файле - вопросы по паттернам
            string answer;
            bool isQuestion = userInput.Contains("?");
            //if (userInput.Contains("?"))
            //    answer = DefaultAnswers[Random.Next(DefaultAnswers.Count())];
            //else
            //    answer = DefaultPhrases[Random.Next(DefaultPhrases.Count())];
            answer = (isQuestion)
                ? DefaultAnswers[Random.Next(DefaultAnswers.Count())]
                : DefaultPhrases[Random.Next(DefaultPhrases.Count())];

            userInput = String.Join(" ", userInput.ToLower().Split("[ {,|.}?]".ToCharArray()));
            foreach (KeyValuePair<string, List<string>> entry in Patterns)
            {
                foreach (string str in entry.Value)
                {
                    Regex regex = new Regex(str);
                    if (regex.IsMatch(userInput))
                    {
                        //answer = PatternAnswers[entry.Key][Random.Next(PatternAnswers[entry.Key].Count())];

                        //пока не запускать, файла нет)))
                        answer = (isQuestion)
                            ? (PatternAnswers.ContainsKey(entry.Key)) 
                                ? PatternAnswers[entry.Key][Random.Next(PatternAnswers[entry.Key].Count())] 
                                : answer
                            : (PatternPhrases.ContainsKey(entry.Key)) 
                                ? PatternPhrases[entry.Key][Random.Next(PatternPhrases[entry.Key].Count())] 
                                : answer;
                    }
                }
            }

            return answer;
        }
    }
}
