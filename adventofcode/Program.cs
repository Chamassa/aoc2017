using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            StartPuzzle();
        }

        private static void StartPuzzle()
        {
            Console.WriteLine("Which day to run? (1-25)");
            string input = Console.ReadLine();
            int day = 0;
            int.TryParse(input, out day);
            if (!(day > 0 && day <= 25))
            {
                StartPuzzle();
                Console.Clear();
                return;
            }
            Console.WriteLine($"Day {day}");
            Thread.Sleep(100);
            Console.WriteLine();
            bool hasPuzzle = false;
            while (!hasPuzzle)
            {
                hasPuzzle = true;
                
                Console.WriteLine("Which puzzle to run? (1;2;both;test1;test2;test)");
                input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                        RunPuzzle(day, 1);
                        break;
                    case "2":
                        RunPuzzle(day, 2);
                        break;
                    case "test1":
                        RunPuzzle(day, -1);
                        break;
                    case "test2":
                        RunPuzzle(day, -2);
                        break;
                    case "test":
                        RunPuzzle(day, -1);
                        RunPuzzle(day, -2);
                        break;
                    case "both":
                        RunPuzzle(day);
                        break;
                    default:
                        hasPuzzle = false;
                        Console.WriteLine("Invalid answer");
                        break;
                }
            }
            Console.ReadLine();
        }

        private static void RunPuzzle(int day, int puzzle = 0)
        {
            try
            {

                Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"Day{day}");
                if (Activator.CreateInstance(type) is Day dayObj)
                {
                    switch (puzzle)
                    {
                        case 1:
                            dayObj.Puzzle1();
                            break;
                        case 2:
                            dayObj.Puzzle2();
                            break;
                        case -1:
                            dayObj.Test1();
                            break;
                        case -2:
                            dayObj.Test2();
                            break;
                        case 0:
                        default:
                            dayObj.Both();
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Day not programmed yet!");
            }
        }
    }
    
}