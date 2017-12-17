using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day13 : Day
    {
        public Day13() : base(13)
        {
        }

        public override void Puzzle1()
        {
            Dictionary<int, int> input = GetInputClean().Replace("\r", "").Split('\n')
                .ToDictionary(k => int.Parse(k.Split(':')[0].Trim()), v => int.Parse(v.Split(':')[1].Trim()));
            int position = -1;
            int max = input.Max(n => n.Key);
            int severity = 0;
            int time = 0;
            while (position <= max)
            {
                position++;
                if (input.Keys.Contains(position))
                {
                    KeyValuePair<int, int> node = input.First(n => n.Key == position);
                    if (time % (2 * node.Value - 2) == 0)
                        severity += (node.Key * node.Value);
                }
                time++;
            }

            Console.WriteLine($"Part 1: {severity}");
        }


        public override void Puzzle2()
        {
            Dictionary<int, int> input = GetInputClean().Replace("\r", "").Split('\n')
                .ToDictionary(k => int.Parse(k.Split(':')[0].Trim()), v => int.Parse(v.Split(':')[1].Trim()));
            int max = input.Max(n => n.Key);

            int severity = 1;
            int delay = -1;
            while (severity > 0)
            {
                delay++;
                severity = 0;
                int position = -1;
                int time = delay;

                while (position <= max)
                {
                    position++;
                    if (input.Keys.Contains(position))
                    {
                        KeyValuePair<int, int> node = input.First(n => n.Key == position);
                        if (time % (2 * node.Value - 2) == 0)
                            severity += (node.Key * node.Value) + 1;
                    }
                    time++;
                }

                //>17500
            }

            Console.WriteLine($"Part 2: {delay}");
        }


        public override void Test1()
        {
            PuzzleInput = "0: 3" + "\n" +
                          "1: 2" + "\n" +
                          "4: 4" + "\n" +
                          "6: 4";
            Puzzle1();
        }

        public override void Test2()
        {
            PuzzleInput = "0: 3" + "\n" +
                          "1: 2" + "\n" +
                          "4: 4" + "\n" +
                          "6: 4";
            Puzzle2();
        }
    }
}