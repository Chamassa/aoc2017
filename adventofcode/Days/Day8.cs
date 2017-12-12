using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day8 : Day
    {
        public Day8() : base(8)
        {
            Input = GetInputClean().Replace("\r", "").Split('\n').ToArray();
        }

        private string[] Input = null;
        public override void Puzzle1()
        {
            int answer = Puzzle().LastMax;
            Console.WriteLine($"Part 1: {answer}");
        }
        

        public override void Puzzle2()
        {
            int answer = Puzzle().ProcessMax;
            Console.WriteLine($"Part 2: {answer}");
        }

        public override void Test1()
        {
            Input = new string[]
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };
            Puzzle1();
            
        }

        public override void Test2()
        {
            Input = new string[]
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };
            Puzzle2();
        }

        private List<Instruction> GetInstructions()
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string ins in Input)
            {
                string[] split = ins.Split(' ');
                instructions.Add(new Instruction
                {
                    Registry = split[0],
                    Action = split[1],
                    Amount = int.Parse(split[2]),
                    CheckRegistry = split[4],
                    CheckAction =  split[5],
                    CheckAmount = int.Parse(split[6])
                });
            }
            return instructions;
        }

        public Answer8 Puzzle()
        {
            int processMax = 0;
            Dictionary<string, int> registry = new Dictionary<string, int>();
            List<Instruction> instructions = GetInstructions();
            registry = instructions.Select(i => i.Registry).Concat(instructions.Select(i => i.CheckRegistry)).Distinct()
                .ToDictionary(s => s, s => 0);
            foreach (var ins in instructions)
            {
                bool check = false;
                switch (ins.CheckAction)
                {
                    case ">":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value > ins.CheckAmount;
                        break;
                    case ">=":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value >= ins.CheckAmount;
                        break;
                    case "<":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value < ins.CheckAmount;
                        break;
                    case "<=":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value <= ins.CheckAmount;
                        break;
                    case "==":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value == ins.CheckAmount;
                        break;
                    case "!=":
                        check = registry.First(r => r.Key == ins.CheckRegistry).Value != ins.CheckAmount;
                        break;
                }
                if (check)
                {
                    registry[ins.Registry] =
                        registry[ins.Registry] + (ins.Action == "inc" ? 0 + ins.Amount : 0 - ins.Amount);
                    processMax = Math.Max(processMax, registry[ins.Registry]);
                }
            }
            return new Answer8() {LastMax = registry.Max(r => r.Value), ProcessMax = processMax};
        }
        
        public class Instruction
        {
            public string Registry { get; set; }
            public string Action { get; set; }
            public int Amount { get; set; }
            public string CheckRegistry { get; set; }
            public string CheckAction { get; set; }
            public int CheckAmount { get; set; }
        }

        public class Answer8
        {
            public int ProcessMax = 0;
            public int LastMax = 0;
        }
    }
}