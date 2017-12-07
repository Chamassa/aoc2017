using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Timers;

namespace adventofcode.Days
{
    public class Day7 : Day
    {
        private string[] Input;

        public Day7() : base(7)
        {
            Input = GetInputClean().Replace("\r", "").Split('\n').ToArray();
        }

        public override void Puzzle1()
        {
            string topLevel = GetTopLevel();
            Console.WriteLine($"Part 1: {topLevel}");
        }

        private string GetTopLevel()
        {
            List<KeyValuePair<string, string>> sets =
                Input.Select(s => s.Split("->")).Select(set =>
                    new KeyValuePair<string, string>(set[0].Trim(), set.Length > 1 ? set[1].Trim() : string.Empty)).ToList();
            string key = sets.First(kvp =>
                kvp.Value != string.Empty && sets.Count(kvp2 => kvp2.Value.Contains(kvp.Key.Split("(")[0].Trim())) == 0).Key.Split("(")[0].Trim();
            return key;
        }

        public override void Puzzle2()
        {
            List<Entry> entries = new List<Entry>();
            foreach (string s in Input)
            {
                Entry e = new Entry();
                string[] split = s.Split("->")[0].Replace(")","").Split("(").Select(str => str.Trim()).ToArray();
                e.Name = split[0];
                e.Weight = int.Parse(split[1]);
                entries.Add(e);
            }
            foreach (string s in Input.Where(str => str.Contains("->")))
            {
                Entry e = entries.Find(entry => entry.Name == s.Split("(")[0].Trim());
                string[] children = s.Split("->")[1].Split(",").Select(str => str.Trim()).ToArray();
                e.Descendants = entries.Where(entry => children.Contains(entry.Name)).ToArray();
            }
            int weightCorrection = 0;
            Entry current = entries.Find(entry => entry.Name == GetTopLevel());
            int targetWeight = 0;
            while (weightCorrection == 0)
            {
                int[] weights = current.Descendants.Select(x => x.ActualWeight()).ToArray();
                if (weights.Distinct().Count() == 1)
                {
                    Console.WriteLine(current.Name);
                    Console.WriteLine(string.Join(",", weights));
                    Console.WriteLine(current.Weight);
                    weightCorrection = Math.Abs(targetWeight - weights.Sum());
                }
                else
                {
                    int errorIndex = -1;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        if (weights.Count(n => n == weights[i]) == 1)
                        {
                            errorIndex = i;
                            break;
                        }
                    }
                    if (errorIndex == 0)
                        targetWeight = weights[1];
                    else
                        targetWeight = weights[0];
                    current = current.Descendants[errorIndex];
                }
            }
            
            Console.WriteLine($"Part 2: {weightCorrection}");
        }

        
        public override void Test1()
        {
            SetTestInput();
            Puzzle1();
        }

        public override void Test2()
        {
            SetTestInput();
            Puzzle2();
        }

        public void SetTestInput()
        {
            Input = new string[]
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };
        }
        public class Entry
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public Entry[] Descendants = new Entry[0];

            public int ActualWeight()
            {
                if (Descendants.Length == 0)
                    return Weight;
                return Descendants.Sum(d => d.ActualWeight()) + Weight;
            }
        }
    }
    
}