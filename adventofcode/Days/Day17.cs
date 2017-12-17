using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day17 : Day
    {
        public Day17() : base(17) {}

        public override void Puzzle1()
        {
            Puzzle(int.Parse(GetInputClean()), 2017);
        }
        

        public override void Puzzle2()
        {
            int steps = int.Parse(GetInputClean());
            int index1 = 0;
            int position = 0;
            for (int i = 1; i <= 50000000; i++)
            {
                position = (position + steps) % i;
                if (position == 0)
                    index1 = i;
                position++;
            }
            Console.WriteLine($"Part 2: {index1}");
        }

        private void Puzzle(int steps, int limit)
        {
            List<int> buffer = new List<int>() {0};
            int position = 0;
            for (int i = 1; i <= limit; i++)
            {
                position = (position + steps) % buffer.Count;
                buffer.Insert(position + 1, i);
                position++;
            }
            Console.WriteLine($"Part 1: {buffer[position+1]}");
        }

        public override void Test1()
        {
            Puzzle(3,2017);
        }

        public override void Test2()
        {
            Puzzle(3,2017);
        }
    }
}