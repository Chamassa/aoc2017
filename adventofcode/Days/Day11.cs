using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day11 : Day
    {

        public string[] Input;

        public Day11() : base(11)
        {
            Input = GetInputClean().Split(',').ToArray();
        }

        public override void Puzzle1()
        {
            int x = 0; //horizontal
            int y = 0; //topleft-bottomright diagonal
            int z = 0; //bottomleft-topright diagonal

            foreach (string dir in Input)
            {
                switch (dir)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                }
            }
            int answer = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int x = 0; //horizontal
            int y = 0; //topleft-bottomright diagonal
            int z = 0; //bottomleft-topright diagonal
            int max = 0;
            foreach (string dir in Input)
            {
                switch (dir)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                }
                int distance = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                if (distance > max)
                    max = distance;
            }
            Console.WriteLine($"Part 2: {max}");
        }

        public override void Test1()
        {
            Input = new string[] {"ne", "ne", "ne"};
            Puzzle1();
            Input = new string[] {"ne", "ne", "sw", "sw"};
            Puzzle1();
            Input = new string[] {"ne", "ne", "s", "s"};
            Puzzle1();
            Input = new string[] {"se","sw","se","sw","sw"};
            Puzzle1();
        }

        public override void Test2()
        {
        }
    }
}