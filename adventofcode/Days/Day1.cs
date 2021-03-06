﻿using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day1 : Day
    {
        public Day1() : base(1) {}

        public override void Puzzle1()
        {
            int answer = Puzzle((i, input) => i + 1 < input.Length ? i + 1 : 0);
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int answer = Puzzle((i, input) => (i + (input.Length / 2)) % input.Length);
            Console.WriteLine($"Part 2: {answer}");
        }

        private int Puzzle(Func<int, string, int> indexSelector)
        {
            string input = GetInputClean();
            return input.Where((chr, idx) => chr == input[indexSelector(idx, input)]).Sum(chr => int.Parse(chr.ToString()));
        }

        public override void Test1()
        {
        }

        public override void Test2()
        {
        }
    }
}