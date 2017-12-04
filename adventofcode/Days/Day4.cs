using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day4 : Day
    {
        private string[][] Input = null;
        public Day4() : base(4)
        {
            Input = GetInputClean().Replace("\r", "").Split('\n').Select(s => s.Split(' ').ToArray()).ToArray();
        }

        public override void Puzzle1()
        {
            int answer = CalculateAnswer();
            Console.WriteLine($"Part 1: {answer}");
        }
        
        public override void Puzzle2()
        {
            Input = Input.Select(line => line.Select(element => string.Concat(element.OrderBy(c => c))).ToArray()).ToArray();
            int answer = CalculateAnswer();
            Console.WriteLine($"Part 2: {answer}");
        }

        public int CalculateAnswer()
        {
            return Input.Count(line => line.Count(element => line.Count(ele2 => ele2 == element) > 1) == 0);
        }

        public override void Test1()
        {
            var OriginalInput = Input;

            Input = new string[][] {new string[] {"aa", "bb", "cc", "dd", "ee"}};
            Puzzle1();
            Input = new string[][] {new string[] {"aa", "bb", "cc", "dd", "aa"}};
            Puzzle1();
            Input = new string[][] {new string[] {"aa", "bb", "cc", "dd", "aaa"}};
            Puzzle1();
            Input = OriginalInput;
        }

        public override void Test2()
        {
            var OriginalInput = Input;

            Input = new string[][] {new string[] {"abcde", "fghij"}};
            Puzzle2();
            Input = new string[][] {new string[] {"abcde", "ecdab", "xyz"}};
            Puzzle2();
            Input = new string[][] {new string[] {"a", "ab", "abc", "abd", "abf", "abj"}};
            Puzzle2();
            Input = new string[][] {new string[] {"iiii", "oiii", "ooii", "oooi", "oooo"}};
            Puzzle2();
            Input = new string[][] {new string[] {"oiii", "ioii", "iioi", "iiio", "abf", "abj"}};
            Puzzle2();
            Input = OriginalInput;
        }
    }
}