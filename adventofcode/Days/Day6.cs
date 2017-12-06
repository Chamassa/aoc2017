using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day6 : Day
    {
        private int[] Input;

        public Day6() : base(6)
        {
        }

        public override void Puzzle1()
        {
            Input = GetInputClean().Replace("\r", "").Split('\t').Select(int.Parse).ToArray();
            int answer = Puzzle();
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            Input = GetInputClean().Replace("\r", "").Split('\t').Select(int.Parse).ToArray();
            Puzzle();
            int answer = Puzzle();
            Console.WriteLine($"Part 2: {answer}");
        }

        public int Puzzle()
        {
            int[] dataBank = Input.ToArray();
            List<string> configurations = new List<string>();
            bool infinite = false;
            int answer = 0;
            int selector = 0;
            configurations.Add(string.Join('-', dataBank));
            while (!infinite)
            {
                selector = dataBank.ToList().IndexOf(dataBank.Max());
                int blocks = dataBank[selector];
                dataBank[selector] = 0;
                for (int i = 1; i <= blocks; i++)
                {
                    int tempSelector = (selector + i) % dataBank.Length;
                    int curValue = dataBank[tempSelector];
                    int newValue = curValue + 1;
                    dataBank[tempSelector] = newValue;
                }
                string config = string.Join('-', dataBank);
                
                answer++;
                if (configurations.Contains(config))
                    infinite = true;
                configurations.Add(config);
            }
            Input = dataBank;
            return answer;
        }
        
        public override void Test1()
        {
            int[] OriginalInput = Input;

            Input = new int[]{0,2,7,0};
            Puzzle1();
            Input = OriginalInput;
        }

        public override void Test2()
        {
        }
    }
}