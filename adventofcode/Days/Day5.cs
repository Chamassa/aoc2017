using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day5 : Day
    {
        private int[] Input;

        public Day5() : base(5)
        {
            Input = GetInputClean().Replace("\r", "").Split('\n').Select(int.Parse).ToArray();
        }

        public override void Puzzle1()
        {
            int answer = Puzzle(false);
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int answer = Puzzle(true);
            Console.WriteLine($"Part 2: {answer}");
        }

        private int Puzzle(bool part2)
        {
            int steps = 0;
            int position = 0;
            while (position >= 0 && position < Input.Length)
            {
                int step = Input[position];
                int newPosition = position + step;
                if (part2)
                    Input[position] = step >= 3 ? step - 1 : step + 1;
                else
                    Input[position]++;
                position = newPosition;
                steps++;
            }
            return steps;
        }
        
        public override void Test1()
        {
        }

        public override void Test2()
        {
        }
    }
}