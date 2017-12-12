using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day12.Properties;

namespace Day12
{
    class Day12
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(12).Result;

            var groupWith0 = new HashSet<int>() { 0 };

            var programs = lines.Select(x =>
                x.Split(new[] { "<->", "," }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray()).Select(x => new Program { Id = x[0], Neighbours = x.Skip(1).ToArray(), Visited = false }).ToArray();

            TrackPipes(groupWith0, programs.FirstOrDefault(x => x.Id == 0), programs);
            Console.WriteLine(groupWith0.Count);
        }

        static void TrackPipes(HashSet<int> inGroup, Program program, Program[] programs)
        {
            if (program.Visited)
            {
                return;
            }

            program.Visited = true;
            inGroup.Add(program.Id);

            foreach (var programNeighbour in program.Neighbours)
            {
                TrackPipes(inGroup, programs.FirstOrDefault(x => x.Id == programNeighbour), programs);
            }
        }
    }
}
