using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day3 : Day
    {
        private int Input = 0;
        public Day3() : base(3)
        {
            Input = int.Parse(GetInputClean());
        }

        public override void Test1()
        {
            int OriginalInput = Input;

            Input = 12;
            Puzzle1();
            Input = 23;
            Puzzle1();
            Input = 1024;
            Puzzle1();
            Input = OriginalInput;
        }

        public override void Test2()
        {
        }


        public override void Puzzle1()
        {
            int row = 0;
            int endPoint = 0;
            for (int i = 0; i < 300; i++)
            {

                if (Math.Pow((i * 2) + 1, 2) > Input)
                {
                    row = i;
                    endPoint= (int) Math.Pow((row * 2) + 1, 2);
                    
                    break;
                }
            }
            int side = row * 2;
            Console.WriteLine($"Input: {Input}, Row: {row}, EndsWith: {endPoint}, Side: {side}");
            int x = 0;
            int y = 0;
            if(Input > endPoint - (1 * side)) //bottom
            {
                y = row;
                x = row - (endPoint - Input);
            }
            else if (Input > endPoint - (2 * side)) //left
            {
                x = row;
                y = row - ((endPoint - (1 * side)) - Input) ;
            }
            else if (Input > endPoint - (3 * side)) //top
            {
                y = row;
                x = ((endPoint - (2 * side)) - Input) - row;
            }
            else  //right
            {
                x = row;
                y = ((endPoint - (3 * side)) - Input) - row;
            }
            int answer = Math.Abs(x) + Math.Abs(y);
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            //Lookup from table
            //Table at: https://oeis.org/A141481/b141481.txt
            int[] lookup = new int[]
            {
                1, 1, 2, 4, 5, 10, 11, 23, 25, 26, 54, 57, 59, 122, 133, 142, 147, 304, 330, 351, 362, 747, 806, 880,
                931, 957, 1968, 2105, 2275, 2391, 2450, 5022, 5336, 5733, 6155, 6444, 6591, 13486, 14267, 15252, 16295,
                17008, 17370, 35487, 37402, 39835, 42452, 45220, 47108, 48065, 98098, 103128, 109476, 116247, 123363,
                128204, 130654, 266330, 279138, 295229, 312453, 330785, 349975, 363010, 369601, 752688, 787032, 830037,
                875851, 924406, 975079, 1009457, 1026827, 2089141, 2179400, 2292124, 2411813, 2539320, 2674100, 2814493,
                2909666, 2957731, 6013560, 6262851, 6573553, 6902404, 7251490, 7619304, 8001525, 8260383, 8391037,
                17048404, 17724526, 18565223, 19452043, 20390510, 21383723, 22427493, 23510079, 24242690, 24612291,
                49977270, 51886591, 54256348, 56749268, 59379562, 62154898, 65063840, 68075203, 70111487
            };
            int answer = lookup.First(x => x > Input);
            Console.WriteLine($"Part 2: {answer}");
        }
    }
}