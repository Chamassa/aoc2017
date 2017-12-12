using System;
using System.Linq;
using System.Text;

namespace adventofcode.Days
{
    public class Day10 : Day
    {
        public Day10() : base(10) {}

        public override void Puzzle1()
        {
            int[] input = GetInputClean().Split(',').Select(s => int.Parse(s.Trim())).ToArray();
            int[] list = Puzzle(input, 1);
            int answer = list[0] * list[1];
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int[] input = Encoding.ASCII.GetBytes(GetInputClean().Trim()).Select(b => (int) b).ToArray();
            input = input.Concat(new int[] {17, 31, 73, 47, 23}).ToArray();
            int[] list = Puzzle(input, 64);
            int[] output = new int[16];
            for (int i = 0; i < 16; i++)
            {
                int xor = list[i * 16];
                for (int j = 1; j < 16; j++)
                {
                    xor = xor ^ list[(i * 16) + j];
                }
                output[i] = xor;
            }
            
            string answer = string.Join("",output.Select(i => i.ToString("X2")));
            Console.WriteLine($"Part 2: {answer}");
        }

        public int[] Puzzle(int[] input, int iterations)
        {
            int[] list = Enumerable.Range(0, 256).ToArray();
            int skipSize = 0;
            int position = 0;
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                foreach (int length in input)
                {
                    int[] sub = list.Concat(list).Skip(position).Take(length).ToArray();
                    sub = sub.Reverse().ToArray();
                    for (int i = 0; i < length; i++)
                    {
                        int pos = (position + i) % 256;
                        list[pos] = sub[i];
                    }
                    position = (position + length + skipSize) % 256;
                    skipSize++;
                }
            }
            return list;
        }


        public override void Test1()
        {
        }

        public override void Test2()
        {
        }
    }
}