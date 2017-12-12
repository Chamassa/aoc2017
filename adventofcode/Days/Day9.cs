using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day9 : Day
    {
        public Day9() : base(9) {}

        public override void Puzzle1()
        {
            
            string input = GetInputClean();
            while (input.Contains('!'))
            {
                int index = input.IndexOf('!');
                input = input.Substring(0, index) + input.Substring(index + 2);
            }

            while (input.Contains('<'))
            {
                int startIndex = input.IndexOf('<');
                int endIndex = input.IndexOf('>');
                input = input.Substring(0, startIndex) + input.Substring(endIndex + 1);
            }

            int answer = 0;
            int rank = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    rank++;
                    answer += rank;
                }else if (input[i] == '}')
                {
                    rank--;
                }
            }
            
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int answer = 0;
            string input = GetInputClean();
            while (input.Contains('!'))
            {
                int index = input.IndexOf('!');
                input = input.Substring(0, index) + input.Substring(index + 2);
            }

            while (input.Contains('<'))
            {
                int startIndex = input.IndexOf('<');
                int endIndex = input.IndexOf('>');
                input = input.Substring(0, startIndex) + input.Substring(endIndex + 1);
                answer += (endIndex - startIndex) - 1;
            }
            Console.WriteLine($"Part 2: {answer}");
        }


        public override void Test1()
        {
        }

        public override void Test2()
        {
        }
    }
}