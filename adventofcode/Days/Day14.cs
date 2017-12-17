using System;
using System.Linq;

namespace adventofcode.Days
{
    public class Day14 : Day
    {
        public Day14() : base(14) {}

        public override void Puzzle1()
        {
            int[,] output = Puzzle();
            int count = 0;
            foreach (int i in output)
            {
                count += i;
            }
            Console.WriteLine($"Part 1: {count}");
        }
        

        public override void Puzzle2()
        {
            int curZone = 2;
            int changed = 1;
            int[,] grid = Puzzle();
            while (true)
            {
                bool hasZoned = false;

                while (changed > 0)
                {
                    changed = 0;
                    for (int x = 0; x < 128; x++)
                    {
                        for (int y = 0; y < 128; y++)
                        {
                            if (grid[x, y] == 1)
                            {
                                int val = 1;
                                if (x > 0)
                                    val = val > grid[x - 1, y] ? val : grid[x - 1, y];
                                if (x < 127)
                                    val = val > grid[x + 1, y] ? val : grid[x + 1, y];
                                if (y > 0)
                                    val = val > grid[x, y - 1] ? val : grid[x, y - 1];
                                if (y < 127)
                                    val = val > grid[x, y + 1] ? val : grid[x, y + 1];
                                if (val > 1)
                                {
                                    grid[x, y] = val;
                                    changed++;
                                }
                                else if (!hasZoned)
                                {
                                    grid[x, y] = curZone;
                                    curZone++;
                                    hasZoned = true;
                                    changed++;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Changed {changed}");
                }
                if (!hasZoned)
                    break;
                changed = 1;
            }
            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 128; y++)
                {
                    Console.Write($"[{grid[x,y]}]\t");
                }
                Console.Write($"\n");
            }
            Console.WriteLine($"Part 2: {curZone - 2}");
        }

        private int[,] Puzzle()
        {
            int[][] reference = new int[][]
            {
                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 0, 1},
                new int[] {0, 0, 1, 0},
                new int[] {0, 0, 1, 1},
                new int[] {0, 1, 0, 0},
                new int[] {0, 1, 0, 1},
                new int[] {0, 1, 1, 0},
                new int[] {0, 1, 1, 1},
                new int[] {1, 0, 0, 0},
                new int[] {1, 0, 0, 1},
                new int[] {1, 0, 1, 0},
                new int[] {1, 0, 1, 1},
                new int[] {1, 1, 0, 0},
                new int[] {1, 1, 0, 1},
                new int[] {1, 1, 1, 0},
                new int[] {1, 1, 1, 1}
            };
            int[,] grid = new int[128,128];
            for (int row = 0; row < 128; row++)
            {
                int col = 0;
                string knotHash = Day10.KnotHash(GetInputClean() + "-" + row.ToString());
                foreach (char c in knotHash)
                {
                    int[] bits = reference[int.Parse(c + "", System.Globalization.NumberStyles.HexNumber)];
                    grid[row, col] = bits[0];
                    grid[row, col+1] = bits[1];
                    grid[row, col+2] = bits[2];
                    grid[row, col+3] = bits[3];
                    col += 4;
                }
            }
            return grid;
        }

        public override void Test1()
        {
            PuzzleInput = "flqrgnkx";
            Puzzle1();
        }

        public override void Test2()
        {
            PuzzleInput = "flqrgnkx";
            Puzzle2();
        }
    }
}