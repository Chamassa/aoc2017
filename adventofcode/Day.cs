using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace adventofcode
{
    public abstract class Day
    {
        protected string PuzzleInput = String.Empty;
        protected readonly int DayNumber = 0;

        protected Day(int dayNumber)
        {
            DayNumber = dayNumber;
            PuzzleInput = GetInput();
        }

        private string GetInput()
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(basePath, "input", $"day{DayNumber}");
            string sessionKey =
                File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "sessionkey"));
            if (!File.Exists(path))
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    
                    using (WebClient client = new WebClient())
                    {
                        
                        client.Headers.Add(HttpRequestHeader.Cookie, $"session={sessionKey}");
                        string inputString = client.DownloadString($"http://adventofcode.com/2017/day/{DayNumber}/input");
                        File.WriteAllText(path, inputString);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return string.Empty;
                }
            }
            return File.ReadAllText(path);
        }

        public void Both()
        {
            Puzzle1();
            Puzzle2();
        }

        public abstract void Puzzle1();
        public abstract void Puzzle2();
        public abstract void Test1();

        protected string GetInputClean()
        {
            string input = PuzzleInput.Trim();
            while (input.EndsWith("\r") || input.EndsWith("\n") || input.EndsWith("\t"))
            {
                input = input.Substring(input.Length - 1).Trim();
            }
            return input;
        }
        
    }
}