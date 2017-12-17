using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day16 : Day
    {
        public Day16() : base(16)
        {
        }

        public override void Puzzle1()
        {
            Puzzle();
        }


        public override void Puzzle2()
        {
            char[] chars = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            };
            string[] input = GetInputClean().Split(',');
            string line = string.Join("", chars.Take(16));
            string lastSeen = "";
            List<string> seen = new List<string>();
            int iterations = 0;
            while (!seen.Contains(lastSeen))
            {
                if(lastSeen != "")
                    seen.Add(lastSeen);
                foreach (string instructions in input)
                {
                    if (instructions[0] == 's')
                    {
                        int move = int.Parse(instructions.Substring(1));
                        line = line.Substring(16 - move) + line.Substring(0, 16 - move);
                    }
                    else if (instructions[0] == 'p')
                    {
                        line = line.Replace(instructions[1], '|').Replace(instructions[3], instructions[1])
                            .Replace('|', instructions[3]);
                    }
                    else if (instructions[0] == 'x')
                    {
                        int[] move = instructions.Trim().Substring(1).Split('/').Select(int.Parse).ToArray();
                        char char0 = line[move[0]];
                        char char1 = line[move[1]];
                        line = line.Replace(char0, '|').Replace(char1, char0)
                            .Replace('|', char1);
                    }
                }
                lastSeen = line;
                iterations++;
            }
            Console.WriteLine($"Index: {seen.IndexOf(lastSeen)}");
            
            line = seen[((int)(1000000000L % (iterations -1))) - 1];


            Console.WriteLine($"Result: {string.Join("", line)}");
        }

        private void Puzzle(int dancers = 16)
        {
            char[] chars = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            };
            string[] input = GetInputClean().Split(',');
            string line = string.Join("", chars.Take(dancers));
            foreach (string instructions in input)
            {
                if (instructions[0] == 's')
                {
                    int move = int.Parse(instructions.Substring(1));
                    line = line.Substring(dancers - move) + line.Substring(0, dancers - move);
                }
                else if (instructions[0] == 'p')
                {
                    line = line.Replace(instructions[1], '|').Replace(instructions[3], instructions[1])
                        .Replace('|', instructions[3]);
                }
                else if (instructions[0] == 'x')
                {
                    int[] move = instructions.Trim().Substring(1).Split('/').Select(int.Parse).ToArray();
                    char char0 = line[move[0]];
                    char char1 = line[move[1]];
                    line = line.Replace(char0, '|').Replace(char1, char0)
                        .Replace('|', char1);
                }
            }
            Console.WriteLine($"Result: {string.Join("", line)}");
        }

        public override void Test1()
        {
            PuzzleInput = "s1,x3/4,pe/b";
            Puzzle(5);
        }

        public override void Test2()
        {
        }
    }
}