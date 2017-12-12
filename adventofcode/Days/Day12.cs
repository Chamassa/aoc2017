using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.Days
{
    public class Day12 : Day
    {
        public Day12() : base(12) {}

        public override void Puzzle1()
        {
            Puzzle();
        }
        
        public override void Puzzle2()
        {
            Puzzle();
        }

        public void Puzzle()
        {
            List<EndPoint> endPoints = SortInput(GetInputClean());
            List<Group> groups = GetGroups(endPoints);
            Console.WriteLine($"Part 1: {groups.First(g => g.EndPoints.Contains(0)).EndPoints.Count}");
            Console.WriteLine($"Part 2: {groups.Count}");
        }

        public List<EndPoint> SortInput(string input)
        {
            List<EndPoint> endPoints = new List<EndPoint>();

            string[] lines = input.Replace("\r", "").Split('\n');

            foreach (string line in lines)
            {
                string[] split = line.Trim().Split("<->");
                endPoints.Add(
                    new EndPoint()
                    {
                        Source = int.Parse(split[0].Trim()),
                        Connections = split[1].Split(',').Select(s => int.Parse(s.Trim())).ToList()
                    }
                );
            }
            
            return endPoints;
        }

        public List<Group> GetGroups(List<EndPoint> endPoints)
        {
            List<Group> groups = endPoints.Select(e => new Group()
            {
                EndPoints = (new int[] {e.Source}).Concat(e.Connections).ToList()
            }).ToList();
            int amount = groups.Count;
            while (amount > 0)
            {
                amount = 0;
                for (int i = groups.Count - 1; i >= 0; i--)
                {
                    try
                    {

                        Group group = groups.Take(i)
                            .FirstOrDefault(g => g.EndPoints.Any(e => groups[i].EndPoints.Contains(e)));
                        if (group != null)
                        {
                            group.EndPoints = group.EndPoints.Concat(groups[i].EndPoints).Distinct().ToList();
                            groups.Remove(groups[i]);
                            amount++;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.StackTrace);
                        Console.WriteLine();
                    }
                }
            }
            return groups;
        }

        public override void Test1()
        {
             PuzzleInput = "0 <-> 2" + "\n" +
                           "1 <-> 1" + "\n" +
                           "2 <-> 0, 3, 4" + "\n" +
                           "3 <-> 2, 4" + "\n" +
                           "4 <-> 2, 3, 6" + "\n" +
                           "5 <-> 6" + "\n" +
                           "6 <-> 4, 5";
            Puzzle1();
            
        }

        public override void Test2()
        {
        }

        public class EndPoint
        {
            public int Source;
            public List<int> Connections;
        }

        public class Group
        {
            public List<int> EndPoints { get; set; }
        }
    }
}