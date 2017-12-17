using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day15 : Day
    {
        public Day15() : base(15) {}

        public override void Puzzle1()
        {
            ulong a = ulong.Parse(GetInputClean().Split('\n')[0].Split("starts with")[1].Trim());
            ulong b = ulong.Parse(GetInputClean().Split('\n')[1].Split("starts with")[1].Trim());
            int match = 0;
            for (long i = 0; i < 40000000; i++)
            {
                a = (a * 16807) % 2147483647;
                b = (b * 48271) % 2147483647;
                if (((short) a & 0xffff) == ((short) b & 0xffff))
                    match++;
            }
            Console.WriteLine($"Part 1: {match}");
        }
        

        public override void Puzzle2()
        {
            ulong a = ulong.Parse(GetInputClean().Split('\n')[0].Split("starts with")[1].Trim());
            ulong b = ulong.Parse(GetInputClean().Split('\n')[1].Split("starts with")[1].Trim());
            int match = 0;
            for (long i = 0; i < 5000000; i++)
            {
                bool first = true;
                while (first || a % 4 > 0)
                {
                    a = (a * 16807) % 2147483647;
                    first = false;
                }
                first = true;
                while (first || b % 8 > 0)
                {
                    b = (b * 48271) % 2147483647;
                    first = false;
                }
                if (((short) a & 0xffff) == ((short) b & 0xffff))
                    match++;
            }
            Console.WriteLine($"Part 2: {match}");
        }


        public override void Test1()
        {
            PuzzleInput = "Generator A starts with 65 \n" +
                          "Generator B starts with 8921";
            Puzzle1();
        }

        public override void Test2()
        {
            PuzzleInput = "Generator A starts with 65 \n" +
                          "Generator B starts with 8921";
            Puzzle2();
        }
    }
}