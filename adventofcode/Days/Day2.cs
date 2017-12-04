using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day2 : Day
    {
        private int[][] Input = null;
        public Day2() : base(2)
        {
            Input = GetInputClean().Replace("\r", "").Split('\n').Select(s => s.Split('\t').Select(int.Parse).ToArray()).ToArray();
        }

        public override void Puzzle1()
        {
            int answer = Input.Sum(row => row.Max() - row.Min());
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int answer = 0;
            foreach (int[] row in Input)
            {
                for (int index = 0; index < row.Length; index++)
                {
                    for (int search = 0; search < row.Length; search++)
                    {
                        if (index != search)
                        {
                            float division = ((float) row[index]) / ((float) row[search]);
                            if (division % 1 == 0)
                                answer += (int) division;
                        }
                    }
                }
            }
            Console.WriteLine($"Part 1: {answer}");
        }

        public override void Test1()
        {
        }

        public override void Test2()
        {
        }
    }
}